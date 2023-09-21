<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="project-meta.aspx.cs" Inherits="adminpanel_project_meta" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<script type="text/javascript">

function setCount(charLength)
{
    document.getElementById('lblcount').innerHTML = charLength;
}


function LimtCharacters(txtMsg, CharLength, indicator)
{
    chars = txtMsg.value.length;
    
    document.getElementById(indicator).innerHTML = CharLength - chars;
    if (chars > CharLength) 
    {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
    }
}
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Project Meta</h2>
	<span class="space10"></span>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="card card-primary">
			<div class="card-header">
				<h3 class="card-title">Project Meta</h3>
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
						<asp:DropDownList ID="ddrProject" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="ddrProject_TextChanged" >
							<asp:ListItem Value="0">-- Select --</asp:ListItem>
						</asp:DropDownList>
					</div>
					
					<div class="form-group col-md-6">
						<label>Meta Description:*</label><span class="text-primary">( Enter Only 160 Characters )</span>

						  <textarea id="txtMeta" runat="server" rows="5" class="txtBox txt-color round3 p100 contBorder nonResize" onkeyup="LimtCharacters(this,160,'lblcount');"></textarea>

						<label id="lblcount" style="background-color:#E2EEF1;color:Red;font-weight:bold;">160</label>
						<%--<asp:TextBox ID="txtMeta" runat="server" CssClass="form-control" Width="100%" 
							TextMode="MultiLine" onkeyup="LimtCharacters(this,160,'lblcount');" MaxLength="160" Height="150"></asp:TextBox>--%>
					</div>
					
				</div>
			</div>	
		</div>
		<!-- Button controls starts -->
		<span class="space10"></span>
		<span class="space10"></span>
		<asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"   />
	</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

