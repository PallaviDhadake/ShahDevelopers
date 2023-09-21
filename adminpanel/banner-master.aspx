<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="banner-master.aspx.cs" Inherits="adminpanel_banner_master" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        createDataTable();
                    }
                });
            };

            createDataTable();
            function createDataTable() {
                $('#<%= gvbanner.ClientID %>').prepend($("<thead></thead>").append($('#<%= gvbanner.ClientID %>').find("tr:first"))).DataTable({
                     columnDefs: [
                         { orderable: false, targets: [0, 1, 2, 3, 4] }
                     ],
                     order: [[0, 'desc']]
                 });

             }
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2 class="pgTitle">Banner Master</h2>
	<span class="space10"></span>
	<div id="editbanner" runat="server">
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
						<label>Banner Image:*</label>
						<asp:FileUpload ID="fuImg" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= photoMrkup %><span class="space5"></span>
					</div>
					
					<div class="form-group col-md-6">
						<label>Display Order :*</label>
						<asp:TextBox ID="txtdisplay" runat="server" CssClass="form-control textarea" Width="100%"   MaxLength="10"></asp:TextBox>
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
		<%--</ContentTemplate>
		</asp:UpdatePanel>--%>
	</div>
	<div id="viewbanner" runat="server">
		<a href="banner-master.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			<asp:GridView ID="gvbanner" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvbanner_RowDataBound" OnRowCommand="gvbanner_RowCommand" OnPageIndexChanging="gvbanner_PageIndexChanging"  >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="bannerId">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="imageName" HeaderText="Image Name">
						<ItemStyle Width="30%" />
					</asp:BoundField>

					 <asp:BoundField DataField="displayOrder" HeaderText="Display Order">
						<ItemStyle Width="10%" />
					</asp:BoundField>

					<asp:TemplateField>
						<ItemStyle Width="10%" />
						<ItemTemplate>
                            <asp:Button ID="moveUp" runat="server" CssClass="gMoveUp" CommandName="Up"/>
                            <asp:Button ID="moveDown" runat="server" CssClass="gMoveDown" CommandName="Down"  />
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

