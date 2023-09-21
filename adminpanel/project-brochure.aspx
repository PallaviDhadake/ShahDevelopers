<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="project-brochure.aspx.cs" Inherits="adminpanel_project_brochure" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Project Brochure</h2>
	<span class="space10"></span>
    <div class="card card-primary">
			<div class="card-header">
				<h3 class="card-title">Project Brochure</h3>
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
						<asp:DropDownList ID="ddrProject" CssClass="form-control" runat="server" AutoPostBack="true" >
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
						</asp:DropDownList>
					</div>
					
					<div class="form-group col-md-6">
						<label>Upload Brochure :*</label>
						<asp:FileUpload ID="flpBrochure" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
					<%--	<%= projPhoto %><span class="space5"></span>--%>
						
					</div>
				</div>
			</div>	
		</div>
		<!-- Button controls starts -->
		<span class="space10"></span>
		<span class="space10"></span>
		<asp:Button ID="btnupload" runat="server" CssClass="btn btn-primary" Text="Upload" OnClick="btnupload_Click"  />
		<asp:Button ID="btnremove" runat="server" CssClass="btn btn-dark" Text="Remove" OnClick="btnremove_Click"  />
<%--	<span class="space20"></span>
	<%=projGallery %>--%>
</asp:Content>

