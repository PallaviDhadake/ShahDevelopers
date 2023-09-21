 <%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="project-documents.aspx.cs" Inherits="adminpanel_project_documents" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
		$(document).ready(function () {
            $('[id$=gvDoc]').DataTable({
				columnDefs: [
					{ orderable: false, targets: [0, 1, 2, 3, 4 ] }
				],
				order: [[0, 'desc']]
			});
		});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	 <h2 class="pgTitle">Projects Document</h2>
	<span class="space10"></span>
	 <div id="editNews" runat="server">
		<div class="card card-primary">
			<div class="card-header">
				<h3 class="card-title"><%=pgTitle %></h3>
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
						<label>Select Project Name:*</label>
						<asp:DropDownList ID="ddrProject" CssClass="form-control" runat="server" AutoPostBack="true" >
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
						</asp:DropDownList>
					</div>
					
					<div class="form-group col-md-6">
						<label>Document Name:*</label>
						<asp:TextBox ID="txtDoc" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="100" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Document Url :*</label>
						<asp:TextBox ID="txtDocUrl" runat="server" CssClass="form-control" MaxLength="200" Width="100%" ></asp:TextBox>
					</div>
					
					
				</div>
			</div>
		</div>
		<!-- Button controls starts -->
		<span class="space10"></span>
		<span class="space10"></span>
		<asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
		<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-outline-info" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDelete_Click" />
		<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-dark" Text="Cancel" OnClick="btnCancel_Click" />
		<div class="float_clear"></div>
		<!-- Button controls ends -->
		<%--</ContentTemplate>
		</asp:UpdatePanel>--%>
	</div>
	<div id="viewNews" runat="server">
		<a href="project-documents.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			<asp:GridView ID="gvDoc" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvDoc_RowDataBound"   >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="ProDocID">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="ProjName" HeaderText="Project Name">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					 <asp:BoundField DataField="ProDocName" HeaderText="Document Name">
						<ItemStyle Width="40%" />
					</asp:BoundField>

					<asp:TemplateField HeaderText="Document Link">
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litDoc" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField> 

					<asp:TemplateField>
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAnch" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>    
				</Columns>
				<EmptyDataTemplate>
					<span class="warning">Its Empty Here... :(</span>
				</EmptyDataTemplate>
				<PagerStyle CssClass="" />
			</asp:GridView>
		</div>
	</div>
</asp:Content>

