<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/profile.master" AutoEventWireup="true" CodeFile="Assign-Course.aspx.cs" Inherits="Auth_Assign_Course" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
    <script src="../jquery.js"></script>
    <style>
        .dropdown-menu::after {
    border-bottom: 6px solid #999999;
    border-left: 6px solid transparent;
    border-right: 6px solid transparent;
    content: "";
    display: inline-block;
    right: 6%;
    position: relative;
    top: -13px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Assign Course
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
   
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

    <div class="col-md-5">
        <div >

        </div>
        <asp:Panel ID="Panel1" runat="server" class="col-md-12">
              <div class=" form-group">
                  <div class="col-md-3">
                 
                 </div>
                  <div class="col-md-9">
               <%--  <asp:DropDownList  ID="ddlcoursetype" CssClass=" form-control" runat="server" 
                AutoPostBack="true" 
                onselectedindexchanged="ddlcoursetype_SelectedIndexChanged" >
                    
                </asp:DropDownList>--%>
                      </div>
                  </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" class="col-md-12" Visible="false">
            <div class=" form-group" >
                   <div class="col-md-3">
                Course Name <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ForeColor="Red" ControlToValidate="ddlCourse" InitialValue="0" ValidationGroup="g"
                        ErrorMessage="Please select Course!"></asp:RequiredFieldValidator>
                        </div>
                  <div class="col-md-9">
              <asp:DropDownList  ID="ddlCourse" CssClass=" form-control" runat="server" 
                onselectedindexchanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true" >  </asp:DropDownList>
                 
                  </div>
                </div>
            <div class=" form-group " style="display:none">
                <div class="col-md-3">
                    Select Teacher
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlteacher" CssClass=" form-control" runat="server">
                    </asp:DropDownList>
                    
                </div>
            </div>
            <div class=" form-group ">
                  <div class="col-md-3">
               Course Fees
                       </div>
                  <div class="col-md-9">
                      <asp:TextBox ID="txtfee" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>

            </div>
            <div class=" form-group none ">
                <div class="col-md-3">
                    Batch Timming
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlbatch" CssClass=" form-control" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ControlToValidate="ddlbatch" InitialValue="select" ValidationGroup="g"
                        ErrorMessage="Please select Batch Time!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class=" form-group none">
                <div class="col-md-3">
                    Room Number
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlroom" CssClass=" form-control" runat="server">
                    </asp:DropDownList>
                  
                </div>
            </div>
            <div class=" form-group">
                  <div class="col-md-3">
               Addmission Date
                       </div>
                  <div class="col-md-9">
                          <div class="input-group">
                              <asp:TextBox  ID="txtAdmitDate" placeholder="DD/MM/YYYY" CssClass="form-control" runat="server"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Addmission Date" ValidationGroup="g" ControlToValidate="txtAdmitDate" Text="*"></asp:RequiredFieldValidator>
                  <asp:CalendarExtender ID="txtAdmitDate_CalendarExtender" PopupButtonID="txtAdmitDate" runat="server" 
                Enabled="True" TargetControlID="txtAdmitDate"  Format="dd/MM/yyyy" CssClass="cal">
                    </asp:CalendarExtender>
                                
                          </div>
                  
                 
                  </div>
             

            </div>
            <div class=" form-group" >
                  <div class="col-md-3">
               End Date
                       </div>
                  <div class="col-md-9">
                      <div class="input-group">
                          <asp:TextBox  ID="txtStartDate" placeholder="DD/MM/YYYY"  CssClass="date form-control" runat="server"/>
                                                  <asp:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server"  PopupButtonID="Image1"
                       Enabled="True" TargetControlID="txtStartDate"  Format="dd/MM/yyyy" CssClass="cal">
                  </asp:CalendarExtender>
                         
                        </div><!-- /input-group -->
                  </div>

            </div>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" class="col-md-12" Visible="false">
            
        </asp:Panel>

        <asp:Panel ID="pnlmid" runat="server" Visible="false">

            
            
        </asp:Panel>
   
    </div>
    <asp:panel id="pnltime" style="display:none" Runat="Server" class="col-md-4">
        
        <hr />
        <asp:GridView ID="grdtest" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" style="text-align:center" 
                    Width="406px" CssClass="table table-bordered" OnRowCommand="grdtest_RowCommand" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
 

   <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" runat="server" Text='<%#Eval("Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
      
                        <asp:TemplateField>
                            <HeaderTemplate>
                             <%--   <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" 
                                    OnCheckedChanged="chkboxSelectAll_CheckedChanged" />--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkfield" class="flat" runat="server" Checked="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <SortedAscendingCellStyle BackColor="White" />
                    <SortedAscendingHeaderStyle BackColor="White" />
                    <SortedDescendingCellStyle BackColor="White" />
                    <SortedDescendingHeaderStyle BackColor="White" />
                </asp:GridView>
    </asp:panel>

    
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:panel ID="pnlcourse" runat="server" class="col-md-7">

     
        <asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server" 
        CellPadding="4" AutoGenerateColumns="False"  OnRowCommand="GrdDetail_RowCommand" OnRowDataBound="GrdDetail_RowDataBound" OnRowDeleting="GrdDetail_RowDeleting">
    
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
                          
           

                              <asp:TemplateField  HeaderText="Addmission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbladmitdate" runat="server" Text='<%#Eval("AdmitDate")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Course End Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblend" runat="server" Text='<%#Eval("enddate")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField  HeaderText="Fees">
                                <ItemTemplate>
                                    <asp:Label ID="lblfee" runat="server" Text='<%#Eval("Fees")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
           
                               <asp:TemplateField  HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Status")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                    <asp:TemplateField >
         <ItemTemplate>
             <table>
               <tr>
                     <td> &nbsp;&nbsp;
                          <asp:LinkButton ID="lnkEdt" ToolTip="Edit Time" ForeColor="white"  CommandName="time"  CommandArgument='<%#Eval("Id") + ";" +Eval("Time")+ ";" +Eval("CourseId")%>' Text="Edit" CssClass="label label-info"  runat="server"></asp:LinkButton>
                                          <asp:LinkButton ID="lnkdeac" CssClass="label label-danger" CommandName="deactive" CommandArgument='<%#Eval("Id")+ ";" +Eval("CourseId")  %>' runat="server">Deactive</asp:LinkButton>

                          </td>
                   <td>
                      
                   </td>
                    
                  
              </tr>
           </table>
       </ItemTemplate>               
     </asp:TemplateField>
    </Columns>
       
    </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="g" OnClick="Button1_Click" CssClass="btn btn-success" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="g" ShowMessageBox="true" ShowSummary="false" DisplayMode="BulletList" />
        <asp:Button ID="btnupdatetime" runat="server" Text="Update" CssClass="btn btn-danger" Visible="false" OnClick="btnupdatetime_Click" />
           <asp:LinkButton ID="lnkassign" runat="server" CssClass="btn btn-info text-right" OnClick="lnkassign_Click" Visible="false">Assing New Time</asp:LinkButton>

    </asp:panel>

    <div class="row">
                <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                    data-toggle="modal" data-target="#myModal">
                    Launch demo modal
                </button>
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title">Your Header here</h4>
                            </div>
                            <div class="modal-body">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Select Course</label>
                             
                                    <asp:DropDownList ID="ddlasigncourse" AutoPostBack="True" runat="server" class="form-control" OnSelectedIndexChanged="ddlasigncourse_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlasigncourse" Text="Select Course" runat="server" ErrorMessage="Select Course" InitialValue="-- Select Course --" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                      </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Select Teacher</label>
                             
                                    <asp:DropDownList ID="ddlasignteacher" runat="server" class="form-control" ></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlasignteacher" Text="Select Teacher Name" runat="server" ErrorMessage="Select Course" InitialValue="select Teacher" ValidationGroup="g1"></asp:RequiredFieldValidator>

                                </div>
                                <div class="form-group">
                                    <asp:ListView ID="lvtime" runat="server" OnItemDataBound="lvtime_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="col-md-3">
                                            <asp:Label ID="lblaid" Visible="false" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                            <asp:CheckBox ID="chka" Text='<%#Eval("Time") %>' runat="server" />
                                                </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                                        </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tt"
                                            EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                

                                <%--<asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-default" OnClick="btnsubmit_Click1" ValidationGroup="g1" />--%>
                                <asp:Button ID="tt" runat="server" OnClick="tt_Click" Text="Submit" class="btn btn-default" />
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                               
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
            </div>

    <div class="row">
                <button type="button" style="display: none;" id="btnShowPopup1" class="btn btn-primary btn-lg"
                    data-toggle="modal" data-target="#myModal1">
                    Launch demo modal
                </button>
                <div class="modal fade" id="myModal1">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title">Your Header here</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Admin Password</label>
                                    <input type="password" class="form-control" id="txtname" placeholder="Name" runat="server">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtname" Text="Please Enter Password" ValidationGroup="g1" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                                </div>

                                <asp:Button ID="Button2" runat="server" Text="Submit" CausesValidation="false" class="btn btn-default" ValidationGroup="g1" OnClick="Button2_Click" />
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                               
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
            </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
     <script type="text/javascript">
         function ShowPopup() {
             $("#btnShowPopup").click();
         }
    </script>
     <script type="text/javascript">
         function ShowPopup2() {
             $("#btnShowPopup1").click();
         }
    </script>
           <script type="text/javascript">
               // When the document is ready
               $(document).ready(function () {

                   $('.date').datepicker({
                       format: "dd/mm/yyyy"
                   });

               });
    </script>
</asp:Content>

