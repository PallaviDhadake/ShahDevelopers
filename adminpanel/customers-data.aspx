<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="customers-data.aspx.cs" Inherits="adminpanel_customers_data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	 <script>
         $(document).ready(function () {
             $('[id$=gvCust]').DataTable({
                 columnDefs: [
                     { orderable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7] }
                 ],
                 order: [[0, 'desc']]
             });
         });
     </script>
	<script type="text/javascript">
        function alpha(e) {
            //alert("Alpha Called");
            var k;
            document.txtPlotNum ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
     <script type="text/javascript">
         function validateNumber(e) {
             const pattern = /^[0-9]$/;

             return pattern.test(e.key)
         }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2 class="pgTitle">Customers Data</h2>
	<span class="space10"></span>
	 <div id="editcust" runat="server">
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
						<label>Select Project Name :*</label>
						<asp:DropDownList ID="ddrProjId" CssClass="form-control" runat="server">
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
						</asp:DropDownList>
					</div>
					
					<div class="form-group col-md-6">
						<label>Plot Number :*</label>
						<asp:TextBox ID="txtPlotNum" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="30" ></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Name :*</label>
						<asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="50" Width="100%" ></asp:TextBox>
					</div>
					
					<div class="form-group col-md-6">
						<label>Mobile No :*</label>
						<asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" MaxLength="10" onkeypress="return validateNumber(event)" Width="100%" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Email  :</label>
						<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50" Width="100%" ></asp:TextBox>
					</div>

						<div class="form-group col-md-6">
						<label>User Id :</label>
						<asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" Enabled="false" MaxLength="
							30" Width="100%" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Password :*</label>
						<asp:TextBox ID="txtPass" runat="server" CssClass="form-control" MaxLength="
							20" Width="100%" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6" id="rapid" runat="server">
						<%--<label>Password :*</label>--%>
						<asp:CheckBox ID="chkbxrapid" runat="server" TextAlign="Right" />
							<label class="form-check-label"><strong>Rapid Entry</strong> </label>
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
		<div id="viewcust" runat="server">
		<a href="customers-data.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			<asp:GridView ID="gvCust" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvCust_RowDataBound"  >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="CustID">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="CustJoinDate" HeaderText="Date">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					 <asp:BoundField DataField="CustName" HeaderText="Customer Name">
						<ItemStyle Width="35%" />
					</asp:BoundField>

					 <asp:BoundField DataField="ProjName" HeaderText="Project Name">
						<ItemStyle Width="30%" />
					</asp:BoundField>

					 <asp:BoundField DataField="CustUserId" HeaderText="User Id">
						<ItemStyle Width="10%" />
					</asp:BoundField>

						 <asp:BoundField DataField="CustPassword" HeaderText="Password">
						<ItemStyle Width="10%" />
					</asp:BoundField>

					 <asp:BoundField DataField="CustMobileNo" HeaderText="Mobile No">
						<ItemStyle Width="10%" />
					</asp:BoundField>


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

