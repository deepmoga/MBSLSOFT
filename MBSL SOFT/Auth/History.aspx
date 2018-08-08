<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/profile.master" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="Auth_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    History
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Label ID="lblcode" Visible="false" runat="server" Text="Label"></asp:Label>
    <div class="col-md-12">
    <asp:GridView ID="gvhistory" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table table-bordered">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>

           <asp:TemplateField HeaderText="Id">
               <ItemTemplate>
                   <%# Container.DataItemIndex+1 %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="Date">
               <ItemTemplate>
                   <%#Eval("Date") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="CourseName">
               <ItemTemplate>
                    <%#Eval("CourseName") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="TeacherName">
               <ItemTemplate>
                    <%#Eval("teachername") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="Time">
               <ItemTemplate>
                    <%#Eval("time") %>
               </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="Status">
               <ItemTemplate>
                    <%#Eval("status") %>
               </ItemTemplate>
           </asp:TemplateField>
             
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        </div>
    <div class="col-md-12">
        <h3>Complete Course</h3>
        <hr />
        <asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server" 
        CellPadding="4" AutoGenerateColumns="False" >
    
       <FooterStyle BackColor="#323b44" ForeColor="White" />
        <HeaderStyle BackColor="#323b44" Font-Size="14px" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#323b44" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
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
       <asp:TemplateField Visible="false" HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("id")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

          <asp:TemplateField  HeaderText="CourseId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcid" runat="server" Text='<%#Eval("CourseId")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

           
            <asp:TemplateField  HeaderText="Course Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("CourseName")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                           <asp:TemplateField  HeaderText="Course Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("Type")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                 
            <asp:TemplateField  HeaderText="Time">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("Time")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField  HeaderText="Addmission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbladmitdate" runat="server" Text='<%#Eval("AdmitDate")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField  HeaderText="Starting Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblstartdate" runat="server" Text='<%#Eval("StartDate")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
           
                               <asp:TemplateField  HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Status")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField  HeaderText="Teacher Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("Teachercode")  %>'></asp:Label>
                                </ItemTemplate>
                                  <EditItemTemplate><%-- <asp:DropDownList SelectedValue='<%# Bind("strategyId") %>'--%> 
                                  
                                     <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Teachercode")%>' Visible="false"></asp:Label>
                                  <asp:DropDownList ID="ddlstatus" runat="server">
                                    </asp:DropDownList>
                                  </EditItemTemplate>
                            </asp:TemplateField>
                                
    </Columns>
       
    </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

