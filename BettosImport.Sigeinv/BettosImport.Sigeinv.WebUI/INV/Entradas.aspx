<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="Entradas.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.INV.Entradas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="btn-toolbar well well-sm" >
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-info" Enabled="true" OnClick="btnNuevo_Click" />
        
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <div class="panel panel-primary">
                
                <div class="panel panel-body">
                    <div class="row">
                        <div class="col-xs-4">
                        
                        </div>
                        <div class="col-xs-8">
                            <div class="input-group"> 
                                <asp:TextBox ID="txtDscModelo" CssClass="form-control" placeholder="Modelo" runat="server" TabIndex="1"></asp:TextBox>
                                <span class="input-group-btn">
                                   <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar"  TabIndex="2" OnClick="btnBuscar_Click" />
                               </span>
                            </div>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gvListado" runat="server" 
                        AutoGenerateColumns="False" 
                        Width="100%" CssClass ="table table-responsive" Font-Size="Small"
                        AllowPaging="True"
                        DataKeyNames="id"
                        EmptyDataText="No se encontraron registros" OnPageIndexChanging="gvListado_PageIndexChanging" OnRowCommand="gvListado_RowCommand">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Código" />
                            <asp:BoundField DataField="dscCategoria" HeaderText="Categoría" />
                            <asp:BoundField DataField="dscSubCategoria" HeaderText="SubCategoría" />
                            <asp:BoundField DataField="dscMarca" HeaderText="Marca" />
                            <asp:BoundField DataField="dscModelo" HeaderText="Modelo" />                
                            <asp:BoundField DataField="dscTipoOperacion" HeaderText="Tipo Entrada" />
                            <asp:BoundField DataField="numCantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="fecEmision" HeaderText="Fecha Emisión" />

                            <asp:ButtonField ButtonType="Button" CommandName="Detail" Text="Ver Detalle" ControlStyle-CssClass="btn btn-sm btn-info" />
                        </Columns>

                    </asp:GridView>     
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
