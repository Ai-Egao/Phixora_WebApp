<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerLocation.aspx.cs" Inherits="Phixora_WebApp.WorkerLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Update My Location</h2>
    <p>Click the button below to send your current location to Phixora.</p>

    <asp:HiddenField ID="hfLatitude" runat="server" />
    <asp:HiddenField ID="hfLongitude" runat="server" />

    <asp:Button ID="btnGetLocation" runat="server" Text="Get My Location"
        CssClass="btn btn-primary" OnClientClick="getLocation(); return false;" />
    <asp:Button ID="btnSaveLocation" runat="server" Text="Save Location"
        CssClass="btn btn-success" OnClick="btnSaveLocation_Click" Visible="false" />

    <p id="lblStatus" style="margin-top:10px; font-weight:bold;"></p>

    <script>
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            } else {
                document.getElementById("lblStatus").innerText = "Geolocation not supported.";
            }
        }

        function showPosition(position) {
            document.getElementById('<%=hfLatitude.ClientID%>').value = position.coords.latitude;
            document.getElementById('<%=hfLongitude.ClientID%>').value = position.coords.longitude;
            document.getElementById("lblStatus").innerText =
                "Location captured! Latitude: " + position.coords.latitude.toFixed(5) +
                ", Longitude: " + position.coords.longitude.toFixed(5);
            document.getElementById('<%=btnSaveLocation.ClientID%>').style.display = "inline-block";
        }

        function showError(error) {
            let msg = "";
            switch (error.code) {
                case error.PERMISSION_DENIED: msg = "Permission denied."; break;
                case error.POSITION_UNAVAILABLE: msg = "Position unavailable."; break;
                case error.TIMEOUT: msg = "Request timeout."; break;
                default: msg = "Unknown error."; break;
            }
            document.getElementById("lblStatus").innerText = msg;
        }
    </script>



</asp:Content>
