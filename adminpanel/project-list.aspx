<%@ Page Title="Project List" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="project-list.aspx.cs" Inherits="adminpanel_project_list" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
		$(document).ready(function () {
            $('[id$=gvProject]').DataTable({
				columnDefs: [
					{ orderable: false, targets: [0, 1, 2, 3, 4, 5] }
				],
				order: [[0, 'desc']]
			});
		});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Project List</h2>
	<span class="space10"></span>
	 <div id="editproj" runat="server">
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
						<label>Project Type :*</label>
						<asp:DropDownList ID="ddrProjType" CssClass="form-control" runat="server">
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
						</asp:DropDownList>
					</div>
					
					<div class="form-group col-md-6">
						<label>Completion Status :*</label>
						<asp:DropDownList ID="ddrcomplstatus" CssClass="form-control" runat="server">
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
							<asp:ListItem Value="1">Current</asp:ListItem>
							<asp:ListItem Value="2">Upcoming</asp:ListItem>
							<asp:ListItem Value="3">Completed</asp:ListItem>
						</asp:DropDownList>
					</div>

					<div class="form-group col-md-6">
						<label>Projec Title:*</label>
						<asp:TextBox ID="txtProjTitle" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="50" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Established Year:*</label>
						<asp:TextBox ID="txtEstbYear" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="4" ></asp:TextBox>
					</div>

					<div class="form-group col-md-12">
						<label>Project Infomation :*</label>
						<asp:TextBox ID="txtProjInfo" runat="server" CssClass="form-control textarea" Height="150px" Width="100%"  textmode="MultiLine"></asp:TextBox>
					</div>
					
					<div class="form-group col-md-6">
						<label>Project Photo:*</label>
						<asp:FileUpload ID="flpPhoto" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= projPhoto %><span class="space5"></span>
						
					</div>

					<div class="form-group col-md-6">
						<label>City:*</label>
						<asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="20" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Build Area:*</label>
						<asp:TextBox ID="txtBldArea" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="20" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Possession:</label>
						<asp:TextBox ID="txtPossession" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="10" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Project Address:*</label>
						<asp:TextBox ID="txtAddData" runat="server" CssClass="form-control" Width="100%" 
							TextMode="MultiLine" Height="150"></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Starting Price:</label>
						<asp:TextBox ID="txtStrtPrice" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="20" placeholder="Rs. 10 Lacs onwards" ></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Buildings:*</label>
						<asp:TextBox ID="txtBuilding" runat="server" CssClass="form-control" Width="100%" 
							 placeholder="5" ></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Configuration:*</label>
						<asp:TextBox ID="txtConfig" runat="server" CssClass="form-control" Width="100%" 
							 placeholder="1, 2, 3 BHK" MaxLength="50"></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Location Importance:*</label> <span class="text-primary">( Mention location importance each new line )</span>
						<asp:TextBox ID="txtLocation" runat="server" TextMode="MultiLine" CssClass="form-control" Width="100%" Height="150"
							 placeholder=""></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Google Map:*</label><span class="text-primary">( Enter lat long )</span>
						<asp:TextBox ID="txtMap" runat="server" CssClass="form-control" Width="100%" 
							 placeholder="17.658443, 75.920334" MaxLength="50"></asp:TextBox>
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
	<div id="viewproj" runat="server">
		<a href="project-list.aspx?action=new" runat="server" class="btn btn-primary btn-md" id="addnew">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			<asp:GridView ID="gvProject" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvProject_RowDataBound" >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="projId">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="projTitle" HeaderText="Project Name">
						<ItemStyle Width="20%" />
					</asp:BoundField>

					 <asp:BoundField DataField="proTypeName" HeaderText="Type">
						<ItemStyle Width="40%" />
					</asp:BoundField>

					 <asp:BoundField DataField="cityName" HeaderText="City">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					<asp:TemplateField HeaderText="Publish Status">
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litStatus" runat="server"></asp:Literal>
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

