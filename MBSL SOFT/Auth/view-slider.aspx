﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-slider.aspx.cs" Inherits="Auth_view_slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    View Slider
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <div class="col-md-12">
    <div class="up-lay griddesign">
        <div class="col-md-8">
            <h2 class="up-name">View Slider</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-danger" 
                onclick="btnback_Click"/>
            &nbsp;<asp:Button ID="btnadd" runat="server" Text="Add Slider" 
                CssClass="btn btn-success" onclick="btnadd_Click" />
        </div>
    </div>
         <div class="col-md-12">
    <div class="table-responsive">
<asp:DataGrid ID="gridlist" runat="server" Width="100%" AutoGenerateColumns="false" 
            onitemcommand="gridlist_ItemCommand" class="table table-striped responsive-utilities jambo_table bulk_action">
    <Columns>
            <asp:TemplateColumn >
                <HeaderTemplate>
                    #</HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                </ItemTemplate>
            </asp:TemplateColumn>

             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      Name
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Name")%></div>
                </ItemTemplate>
              
        </asp:TemplateColumn>
             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      Image
                </HeaderTemplate>
                <ItemTemplate > 
                  <div style=" text-align:center;height: 25px;
overflow: hidden;">
                      <img src="../uploadimage/<%#Eval("Image") %>" width="40px" />

                  </div>
                </ItemTemplate>
              
           </asp:TemplateColumn>
           <asp:TemplateColumn>
                <HeaderTemplate>
                Action
                </HeaderTemplate>
                <ItemTemplate>
                         <table>
               <tr>
               <td> &nbsp;
                     <asp:ImageButton ToolTip='<%# Eval("Status").ToString() == "True" ? "Deactivate" :"Activate" %>' ImageUrl ='<%# Eval("Status").ToString() == "True" ? "images/active.jpg":"images/deactive.jpg" %>' ID="lbnActivate" runat="Server" CommandName='<%# Eval("Status").ToString() == "True" ? "Deactivate":"Activate" %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'/>
                </td>
                   <td>                        
               <asp:ImageButton ToolTip="Edit "   runat="server" ID="lnkEdit" ImageUrl="images/edit.png"  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>
           
               </tr>
               </table>
                </ItemTemplate>
                   <HeaderStyle HorizontalAlign="center" />
                   <ItemStyle HorizontalAlign="center" />
            </asp:TemplateColumn>
        </Columns>
        <HeaderStyle BackColor="#1ABB9C" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
</asp:DataGrid>
</div>
             </div>
         </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

