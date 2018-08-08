<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Finished-Course.aspx.cs" Inherits="Auth_Finished_Course" %>

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
    Finished Course
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <asp:Label ID="lblcode" Visible="false" runat="server" Text="Label"></asp:Label>
    <div class="col-md-12">

    </div>
   <asp:Panel ID="Panel1" runat="server" Height="400px" 
                       Width="100%" ScrollBars="Vertical">
    <div class="col-md-12">
        <asp:GridView ID="gvhistory" runat="server" AutoGenerateColumns="False" OnRowCommand="gvhistory_RowCommand" OnRowDataBound="gvhistory_RowDataBound" CssClass="table table-bordered">
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

            </Columns>
        </asp:GridView>
        </div>
        
       </asp:Panel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

