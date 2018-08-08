<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Complete-Course.aspx.cs" Inherits="Auth_Complete_Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
    <style type="text/css">
  .header
  {
    font-weight:bold;
    position:absolute;
    background-color:White;
  }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Complete Course

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <asp:Label ID="lblcode" Visible="false" runat="server" Text="Label"></asp:Label>
    <div class="col-md-12">
        <asp:CheckBox ID="chkcom" Visible="false" runat="server" Text="Check Complete Course" AutoPostBack="true" OnCheckedChanged="chkcom_CheckedChanged" />
    </div>
   <asp:Panel ID="Panel1" runat="server" Height="400px" 
                       Width="100%" ScrollBars="Vertical">
    <div class="col-md-12">
    <asp:GridView ID="gvhistory" runat="server"  AutoGenerateColumns="False" CellPadding="4" OnRowCommand="gvhistory_RowCommand" ForeColor="#333333" OnRowDataBound="gvhistory_RowDataBound" GridLines="None" CssClass="table table-bordered">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>

           <asp:TemplateField HeaderText="Id">
               <ItemTemplate>
                   <%# Container.DataItemIndex+1 %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="RollNo">
               <ItemTemplate>
                   <%#Eval("rollno") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="Name">
               <ItemTemplate>
                    <%#Eval("name") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="Father Name">
               <ItemTemplate>
                    <%#Eval("fname") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="CourseName">
               <ItemTemplate>
                    <%#Eval("CourseName") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="StartDate">
               <ItemTemplate>
                   
                   <asp:Label ID="lblstart" runat="server" Text=' <%#Eval("StartDate") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
             <asp:TemplateField HeaderText="Complete Date">
               <ItemTemplate>
                   
                   <asp:Label ID="lblcom" runat="server" Text=''></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>

              <asp:TemplateField HeaderText="CourseId" Visible="false">
               <ItemTemplate>
                    
                   <asp:Label ID="lblcid" runat="server" Text='<%#Eval("CourseId") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
             <asp:TemplateField HeaderText="Action">
               <ItemTemplate>
                    
                   <asp:LinkButton ID="lnkcom" CommandName="com" CommandArgument='<%#Eval("rollno")+","+Eval("CourseId")+","+Eval("StartDate") %>' runat="server" CssClass="label label-primary">Complete</asp:LinkButton>
<%--            <asp:ImageButton ToolTip='<%# Eval("Activate").ToString() == "True" ? "Deactivate Doctor":"Activate Doctor" %>' ImageUrl ='<%# Eval("Activate").ToString() == "True" ? "images/active.jpg":"images/deactive.jpg" %>' ID="lbnActivate" runat="Server" CommandName='<%# Eval("Activate").ToString() == "True" ? "Deactivate":"Activate" %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"rollno") %>'/>--%>
               
               </ItemTemplate>
           </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" />
      
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        </div>
        
       </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

