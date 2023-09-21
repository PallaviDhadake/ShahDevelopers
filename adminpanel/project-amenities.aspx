<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="project-amenities.aspx.cs" Inherits="adminpanel_project_amenities" %>

<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="pgTitle">Project List</h2>
    <span class="space10"></span>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Floor Plan</h3>
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
                            <asp:DropDownList ID="ddrProject" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrProject_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <%-- Ammenities start --%>
                    <div id="proAmenities" runat="server">
                        <div class="amenities">
                            <asp:CheckBox ID="chkLift" runat="server" Text=" Lift" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkSecurity" runat="server" Text=" Security" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlayArea" runat="server" Text=" Play Area" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPowerBK" runat="server" Text=" Power Backup" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkSwimmingPool" runat="server" Text=" Swimming Pool" CssClass="check-box" />
                        </div>
                        <div class="clrFlt"></div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkGymnasium" runat="server" Text=" Gymnasium" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkJoggingTrk" runat="server" Text=" Jogging Track" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkInternet" runat="server" Text=" Internet" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkGarden" runat="server" Text=" Garden" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkLibrary" runat="server" Text=" Library" CssClass="check-box" />
                        </div>
                        <div class="clrFlt"></div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkCommunityHall" runat="server" Text=" Community Hall" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkInternalrd" runat="server" Text=" Internal Roads" CssClass="check-box" />
                        </div>
                        <div class="clrFlt"></div>
                    </div>
                    <div id="plotAmenities" runat="server">
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotRoads" runat="server" Text=" Internal Tar Roads" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotElec" runat="server" Text=" Electricity" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotWater" runat="server" Text=" Water Supply" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotDrainage" runat="server" Text=" Drainage" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotGarden" runat="server" Text=" Landscaped Garden" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotPlay" runat="server" Text=" Children's Play Area" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotStrLight" runat="server" Text=" Street Light" CssClass="check-box" />
                        </div>
                        <div class="amenities">
                            <asp:CheckBox ID="chkPlotHarvest" runat="server" Text=" Rain Water Harvest" CssClass="check-box" />
                        </div>
                        <div class="clrFlt"></div>
                    </div>
                </div>
            </div>
            <!-- Button controls starts -->
            <span class="space10"></span>
            <span class="space10"></span>
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            <span class="space20"></span>

            <%-- Other Ammenities --%>

            <div id="OtherAmenities" runat="server">
                <h1>Other Amenities</h1>

                <div class="form-group col-md-6">
                    <label>Select Project :*</label>
                    <asp:DropDownList ID="ddrOAmenities" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddrOAmenities_SelectedIndexChanged">
                        <asp:ListItem Value="0">-- Select other amenities --</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <%-- <div class="col30p">
                    <div class="pad_10">
                        <label class="label-span label-color">Other amenities:</label>
                    </div>
                </div>
                <div class="col70p">
                    <div class="pad_10">
                        <asp:DropDownList ID="ddrOAmenities" runat="server"
                            CssClass="txtBox txt-color round3 ddr100 contBorder" AutoPostBack="True"
                            OnSelectedIndexChanged="ddrOAmenities_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select other amenities</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>--%>

                <div class="formPanel table-responsive-md">
                    <asp:GridView ID="gvAmenities" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None"
                        AutoGenerateColumns="false" OnRowDataBound="gvAmenities_RowDataBound">
                        <HeaderStyle CssClass="thead-dark" />
                        <RowStyle CssClass="" />
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:BoundField DataField="aiId">
                                <HeaderStyle CssClass="HideCol" />
                                <ItemStyle CssClass="HideCol" />
                            </asp:BoundField>

                            <asp:BoundField DataField="aiName" HeaderText="Amenities">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="projId" HeaderText="Project Id">
                                <ItemStyle Width="40%" />
                            </asp:BoundField>

                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <%--<asp:Literal ID="litAnch" runat="server"></asp:Literal>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <span class="warning">Its Empty Here... :(</span>
                        </EmptyDataTemplate>
                        <PagerStyle CssClass="" />
                    </asp:GridView>
                </div>

                <div class="pad_10">
                    <asp:Button ID="cmdSaveOthr" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="cmdSaveOthr_Click" />
                    <span class="space20"></span>
                    <div class="clrFlt"></div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

