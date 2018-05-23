
<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div class="panel panel-primary">
                
                <div class="panel panel-body">
                    <div class="row">
                        <div class="col-xs-4">
                        
                        </div>
                        <div class="col-xs-8">
                            <div class="input-group"> 
                                <asp:TextBox ID="txtDscProducto" CssClass="form-control" placeholder="Producto" runat="server" TabIndex="1"></asp:TextBox>
                                <span class="input-group-btn">
                                   <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="btnBuscar_Click" TabIndex="2" />
                               </span>
                            </div>
                            <br />
                            <div class="col-lg-4">
                                <p class="text-danger"><b>TOTAL: </b><label id="lblTotal" runat="server" ></label> </p>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gvListado" runat="server" 
                        AutoGenerateColumns="False" 
                        Width="100%" CssClass ="table table-responsive" Font-Size="Small"
                        AllowPaging="True"
                        EmptyDataText="No se encontraron registros" 
                        OnPageIndexChanging="gvListado_PageIndexChanging">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Código" />
                            <asp:BoundField DataField="dscProducto" HeaderText="Producto" />
                            <asp:BoundField DataField="dscTienda" HeaderText="Tienda" />
                            <asp:BoundField DataField="cntProducto" HeaderText="Cantidad" />
                        </Columns>

                    </asp:GridView>    
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
