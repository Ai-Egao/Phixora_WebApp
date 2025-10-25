<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerDashboard.aspx.cs" Inherits="Phixora_WebApp.WorkerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Welcome, <asp:Label ID="lblName" runat="server" /></h2>
    <p>Profession: <asp:Label ID="lblProfession" runat="server" /></p>

    <hr />

    <!-- 📅 Upcoming Appointments -->
    <h3>Your Upcoming Appointments</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered"></asp:GridView>

    <hr />

    <!-- 📍 Location Update Section -->
    <h3>Update My Current Location</h3>
    <p>Step 1: Click <b>Get My Location</b> to capture your current coordinates.<br />
       Step 2: Click <b>Save My Location</b> to store them in the database.</p>

    <!-- Hidden fields to store coordinates -->
    <asp:HiddenField ID="hfLatitude" runat="server" />
    <asp:HiddenField ID="hfLongitude" runat="server" />

    <!-- Buttons -->
    <asp:Button ID="btnGetLocation" runat="server" Text="Get My Location"
        CssClass="btn btn-primary" OnClientClick="getLocation(); return false;" />

    <asp:Button ID="btnSaveLocation" runat="server" Text="Save My Location"
        CssClass="btn btn-success" OnClick="btnSaveLocation_Click" Visible="true" />

    <!-- Status message -->
    <p id="lblStatus" style="margin-top:10px; font-weight:bold;"></p>

    <!-- JavaScript for location -->
    <script>
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            } else {
                document.getElementById("lblStatus").innerText = "Geolocation not supported by this browser.";
            }
        }

        function showPosition(position) {
            document.getElementById('<%=hfLatitude.ClientID%>').value = position.coords.latitude;
            document.getElementById('<%=hfLongitude.ClientID%>').value = position.coords.longitude;
            document.getElementById("lblStatus").innerText =
                "Location captured! Latitude: " + position.coords.latitude.toFixed(5) +
                ", Longitude: " + position.coords.longitude.toFixed(5);
            
            // ✅ Make the Save button visible
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
 