<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="Auth_Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
<div class="col-md-8">

        
          <div class="form-group">
           <div class="col-md-3">
               <label>Upload Result</label>
               </div>
                <div class="col-md-9">
               <asp:FileUpload ID="FileUpload1" runat="server" />
          </div></div>
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" OnClick="btnsubmit_Click"/>
              <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Excel Sample Download</asp:LinkButton>
        </div>
    </div>

    <div class="col-md-12">
         
    <asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server" 
        CellPadding="4" AutoGenerateColumns="False"   PageSize="20" AllowPaging="True"  
        BorderColor="black" BorderStyle="None" BorderWidth="1px" 
            style=" width:100%; text-align:center"  class="table table-bordered" >
    
        <FooterStyle BackColor="#323b44" ForeColor="White" />
        <HeaderStyle BackColor="#323b44" Font-Size="14px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        <PagerStyle BackColor="#323b44" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle  ForeColor="#333333" />
        <SelectedRowStyle BackColor="#323b44" Font-Bold="True" ForeColor="white" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />

        <Columns>
       
                    <asp:TemplateField HeaderText="Sr. No.">
                      <ItemTemplate>
                          <%# Container.DataItemIndex + 1 %>
                     </ItemTemplate>
                      
                   </asp:TemplateField>
                   <asp:TemplateField  HeaderText="Roll No">
                      <ItemTemplate>
                           
                            <asp:Label ID="lblroll"  runat="server" Text='<%#Eval("RollNo")  %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
            <asp:TemplateField  HeaderText="Name">
                      <ItemTemplate>
                           
                            <asp:Label ID="lblname"  runat="server" Text='<%#Eval("name")  %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
            <asp:TemplateField  HeaderText="Father Name">
                      <ItemTemplate>
                           
                            <asp:Label ID="lblroll"  runat="server" Text='<%#Eval("fname")  %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField  HeaderText="Place">
                      <ItemTemplate>
                           
                            <asp:Label ID="lblcid"  runat="server" Text='<%#Eval("Place")  %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
         
              <%--    <asp:TemplateField  HeaderText=" Year">
                        <ItemTemplate>
                              <asp:Label ID="lblname" runat="server" Text='<%#Eval("Year")  %>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                --%>

 
              
        </Columns>
       
     </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

