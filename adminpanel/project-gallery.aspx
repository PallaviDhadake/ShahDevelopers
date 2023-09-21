<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="project-gallery.aspx.cs" Inherits="adminpanel_project_gallery" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Project Gallery</h2>
	<span class="space10"></span>
    <div class="card card-primary">
			<div class="card-header">
				<h3 class="card-title">Project Gallery</h3>
			</div>
			<%-- Card Body --%>
			<div class="card-body">
				<div class="colorLightBlue">
					<%--<span>Id</span>--%>
					<asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
				</div>
				<span class="space15"></span>
				<%-- From Row Start --%>
				<div class="form-row">
					<div class="form-group col-md-6">
						<label>Select Project :*</label>
						<asp:DropDownList ID="ddrProject" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrProject_SelectedIndexChanged" >
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
						</asp:DropDownList>
					</div>
					
					<div class="form-group col-md-6">
						<label>Project Photo :*</label>
						<asp:FileUpload ID="flpPhoto" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
					<%--	<%= projPhoto %><span class="space5"></span>--%>
						
					</div>
				</div>
			</div>	
		</div>
		<!-- Button controls starts -->
		<span class="space10"></span>
		<span class="space10"></span>
		<asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
	<span class="space20"></span>
	<%=projGallery %>
</asp:Content>

