<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="DetalleSalida.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.INV.DetalleSalida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <div class="panel panel-primary">
                <div class="panel panel-heading clearfix">
                    <h4 class="panel-title pull-left" style="padding-top: 7.5px;">Detalle Salida</h4>  
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="lbRegresar" CssClass="btn btn-success" OnClick="lbRegresar_Click">
                            <i class="glyphicon glyphicon-arrow-left" aria-hidden="true"></i> Retornar
                        </asp:LinkButton>                  
                    </div> 
                </div>  
                <div class="panel panel-body">
              
                   <div class="row">
                         <div class="col-lg-4">
                                <p class="text-danger"><b>Producto: </b><label id="lblProducto" runat="server" ></label> </p>
                         </div>
                         <div class="col-lg-4">
                                <p class="text-danger"><b>Tipo Salida: </b><label id="lblTipoSalida" runat="server" ></label> </p>
                         </div>
                    </div> 
                    <br />                        
                </div>           
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
