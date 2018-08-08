 <%@ Page Title="" Language="C#" MasterPageFile="~/Auth/profile.master" AutoEventWireup="true" CodeFile="add-qualification.aspx.cs" Inherits="Auth_add_qualification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
 <div class="col-md-8">
        <div >

        </div>
              <div class=" form-group">
                  <div class="col-md-3">

               <label>Course</label>
               </div>
                <div class="col-md-9">
               <asp:DropDownList ID="ddlCourseType" CssClass=" form-control" runat="server" >
                <asp:ListItem>Select Course</asp:ListItem>
               <asp:ListItem>Matric</asp:ListItem>
               <asp:ListItem>Under Graduate</asp:ListItem>
               <asp:ListItem>Vocational Course</asp:ListItem>
               <asp:ListItem>Graduation</asp:ListItem>
               <asp:ListItem>Post Graduation</asp:ListItem>
               </asp:DropDownList>
             </div>
          </div>
        <div class="form-group">
         <div class="col-md-3">
               <label>Percentage</label>
                </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtmarks" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
          </div></div>
          <div class="form-group">
           <div class="col-md-3">
               <label>Board/University</label>
               </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtboard" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
          </div></div>
          <div class="form-group">
          <div class="col-md-3">
               <label>Batch</label>
                 </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtbatch" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
          </div></div>
          <div class="form-group">
             <div class="col-md-3">
                        <label>Documents</label>
                           </div>
                <div class="col-md-9">
                        <asp:FileUpload ID="docimage" runat="server" CssClass="form-control" />   
          </div></div>
          <div class="form-group">
                   <asp:Button CssClass="btn btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
    </div>
    <%--<div class="col-md-4">
                    <img alt="" src="../uploadimage/<%=img %>" width="80"/>
    </div>--%>
<hr />


<div class="col-md-12">
    <asp:ListView ID="gridlist" runat="server" 
        onitemcommand="gridlist_ItemCommand1" onitemediting="gridlist_ItemEditing">
        <ItemTemplate>

  <div class="col-sm-6 col-md-3">
    <div class="thumbnail">
      <img src="../uploadimage/<%#Eval("matric_document") %>" alt="...">
      <div class="caption">
        <h3><%# Eval("course_type")%></h3>
        <ul class="list-group">
            <li class="list-group-item">
            <span class="badge"><%# Eval("matric_per")%></span>
               Marks
            </li>
            <li class="list-group-item">
            <span class="badge"><%# Eval("matric_batch")%></span>
               Batch
            </li>
        </ul>
        <p>
            <asp:LinkButton ID="lnkedit" runat="server" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' CssClass="label label-info" >Edit</asp:LinkButton></p>
      </div>
    </div>
  </div>
  
        </ItemTemplate>
    </asp:ListView>
</div>
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
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Enter Admin Password</label>
                                    <input type="text" class="form-control" id="txtname" placeholder="Name" runat="server">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" Text="Please Enter Password" ValidationGroup="g1" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                                </div>
                                

                                <asp:Button ID="btncheck" runat="server" Text="Submit" class="btn btn-default" 
                                    ValidationGroup="g1" onclick="btncheck_Click" />
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
</asp:Content>

