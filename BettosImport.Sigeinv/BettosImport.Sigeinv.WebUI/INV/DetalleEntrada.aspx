<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="DetalleEntrada.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.INV.DetalleEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <div class="panel panel-primary">
                <div class="panel panel-heading clearfix">
                    <h4 class="panel-title pull-left" style="padding-top: 7.5px;">Detalle Entrada</h4>  
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="lbRegresar" CssClass="btn btn-success" OnClick="lbRegresar_Click">
                            <i class="glyphicon glyphicon-arrow-left" aria-hidden="true"></i> Retornar
                        </asp:LinkButton>                  
                    </div> 
                </div>  
                <div class="panel panel-body">
              
                   <div class="row">
                         <div class="col-lg-4">
                                <span class = "label label-danger"><b>Tipo Entrada:</b></span>&nbsp
                                <label class="text-info" id="lblTipoEntrada" runat="server" ></label>
                         </div>

                         <div class="col-lg-4">
                                <span class = "label label-danger"><b>Origen:</b></span>&nbsp
                                <label class="text-info" id="lblTiendaOrigen" runat="server" ></label>
                         </div>

                         <div class="col-lg-4">
            
                                <span class = "label label-danger"><b>Proovedor:</b></span>&nbsp
                                <label class="text-info" id="lblProveedor" runat="server" ></label>
                         </div>
                    
                   </div> 
                   <br />     
                    
                   <div class="row">
                         <div class="col-lg-4">
                                <span class = "label label-danger"><b>Producto:</b></span>&nbsp
                                <label class="text-info" id="lblProducto" runat="server" ></label>
                         </div>

                         <div class="col-lg-4">
                                <span class = "label label-danger"><b>Cantidad:</b></span>&nbsp
                                <label class="text-info" id="lblCantidad" runat="server" ></label>
                         </div>
                    
                        <div class="col-lg-4">
                                <span class = "label label-danger"><b>Tipo de Documento:</b></span>&nbsp
                                <label class="text-info" id="lblTipoDoc" runat="server" ></label>
                        </div>
          
                   </div> 
                   <br /> 
                    
                   <div class="row">
                        <div class="col-lg-4">
            
                                <span class = "label label-danger"><b>Nº Documento:</b></span>&nbsp
                                <label class="text-info" id="lblNumDoc" runat="server" ></label>
                        </div>
                        <div class="col-lg-4">
                                <span class = "label label-danger"><b>Fecha de Recepción:</b></span>&nbsp
                                <label class="text-info" id="lblFecEmision" runat="server" ></label>
                        </div>

                        <div class="col-lg-4">
                                <span class = "label label-danger"><b>Comentario:</b></span>&nbsp
                                <label class="text-info" id="lblComentario" runat="server" ></label>
                        </div>  
                              
                   </div> 
                   <br />                            
                </div>           
            </div>         
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
