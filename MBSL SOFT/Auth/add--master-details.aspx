<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="add--master-details.aspx.cs" Inherits="Auth_add__master_details" %>



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
    Setting
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">

<div class="col-md-8">
    
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Panel ID="PnlCategory" runat="server" Visible="false" CssClass="pnlstyle box1 effect7">
    <br />
        <div class="panel panel-success">
          <div class="panel-heading">
            <h3 class="panel-title">Add Room </h3>
          </div>
          <div class="panel-body">
            <div class=" form-group">
                    <asp:Label ID="Label1" runat="server" Style="color:#323b44" Text="Room Id:"></asp:Label> 
                    <asp:TextBox ID="txtCategoryCode" Enabled="false" CssClass=" form-control" runat="server"></asp:TextBox>
            </div>
              <div class=" form-group">
                  <asp:Label ID="Label2" Style="color:#323b44" runat="server" Text="Room No:"></asp:Label> 
                    <asp:TextBox ID="txtCategoryName" required="" CssClass=" form-control" runat="server" placeholder="E.g 1"></asp:TextBox>
              </div>
              <div class="form-group">
                  <asp:Button ID="fvAddCategory" CssClass="btn btn-success" runat="server" Text="Submit" onclick="fvAddCategory_Click" /> 
                    <asp:Button ID="fvReset" runat="server" CssClass="btn btn-danger" Text="Reset" onclick="fvReset_Click" />
              </div>
          </div>
    </div>
     
    
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlBatch" Visible="false" runat="server">
        <div class="form-group">
            <label for="exampleInputName2">From</label>
            <asp:TextBox ID="txtFrom" TextMode="Time" CssClass="form-control" required placeholder="00:00" runat="server"></asp:TextBox> 
        </div>
        <div class="form-group">
            <label for="exampleInputEmail2">To</label>
            <asp:TextBox ID="txtTo" TextMode="Time" CssClass="form-control" placeholder="00:00" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="fv1AddBatch" runat="server" Text="Submit" 
        OnClientClick="return ValidateForm1()" CssClass="btn btn-default" onclick="fv1AddBatch_Click" 
         />  &nbsp;&nbsp;&nbsp;  
   
    
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlCourse"  Visible="false" CssClass="pnlstyle box1 effect7" runat="server" >

<div class="panel panel-success">
  <div class="panel-heading">
    <h3 class="panel-title">Course</h3>
  </div>
  <div class="panel-body">
    <div class="form-group">
        <label>Course Id:</label>
        <asp:TextBox ID="txtCourseId" CssClass=" form-control" runat="server" Enabled="False" 
            ReadOnly="True"></asp:TextBox>

    </div>
      <div class="form-group">
          <label>Course Name</label>
          <asp:TextBox ID="txtCourseName" required CssClass=" form-control" runat="server"></asp:TextBox>
      </div>
      <div class="form-group none">
          <label>Duration</label>
          <asp:TextBox ID="txtDuration"  CssClass=" form-control" Text="."  runat="server">
              </asp:TextBox>
      </div>
      <div class="form-group none">
          <label>Course Type</label>
          <asp:DropDownList ID="ddlCourseType" CssClass=" form-control"   runat="server" >
<%--<asp:ListItem>University Course</asp:ListItem>
<asp:ListItem>Course</asp:ListItem>
<asp:ListItem>Red Cross Course</asp:ListItem>--%>
    </asp:DropDownList>
      </div>
      <div class="form-group">
          <label>Duration</label>
          <asp:DropDownList ID="ddlDurationType" CssClass=" form-control" runat="server">
<asp:ListItem>Weeks</asp:ListItem>
<asp:ListItem>Months</asp:ListItem>
<asp:ListItem>Years</asp:ListItem>
    </asp:DropDownList>
      </div>
      <div class="form-group none">
          <label>Eligibility</label>
           <asp:TextBox ID="txtEligibility"   CssClass=" form-control" Text="." runat="server"></asp:TextBox>
      </div>
      <div class="form-group">
          <label>Fees</label>
          <asp:TextBox ID="txtFee"   CssClass=" form-control" runat="server" Text="0"  AutoPostBack="true"></asp:TextBox>
      </div>
      <div class="form-group ">
          <label>2 Month Fee</label>
          <asp:TextBox ID="txt2"   CssClass=" form-control" runat="server"  Text=""></asp:TextBox>
      </div>
      <div class="form-group ">
          <label>3 Month Fee</label>
          <asp:TextBox ID="txt3"   CssClass=" form-control" runat="server"  Text=""></asp:TextBox>
      </div>
      <div class="form-group ">
          <label>4 Month Fee</label>
          <asp:TextBox ID="txt4"   CssClass=" form-control" runat="server"  Text=""></asp:TextBox>
      </div>
      <div class="form-group none">
          <label>Ammount Per Installement</label>
          <asp:TextBox ID="txtinstalamount"   CssClass=" form-control" runat="server"  Text="0"></asp:TextBox>
      </div>
        <div class="form-group none">
            <label>Minimum Hours</label>
             <asp:TextBox ID="txtMinHour"   CssClass=" form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group none">
            <label>Durations in Words</label>
             <asp:TextBox ID="txtdurWords"   CssClass=" form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
             <asp:Button ID="fvAddCourse" CssClass="btn btn-success" 
        runat="server" Text="Submit"  OnClientClick="return ValidateForm()" 
        onclick="fvAddCourse_Click"  />
          &nbsp;
    <asp:Button ID="fvReset1" runat="server" CssClass="btn btn-danger" 
        Text="Reset" />
        </div>
    
  </div>
</div>
    
 </asp:Panel>
  <br />

    <asp:Panel ID="Pnlteacher" Visible="false" runat="server" CssClass="pnlstyle box1 effect7">


        <h3>Add Teacher</h3>
            <br />

    
                       <div class="form-group">
                        <asp:Label ID="lblteacher" runat="server" Style="color:#323b44" Text="Teacher Code:"></asp:Label> 
                         &nbsp;
                        <asp:TextBox ID="txtcode" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                            <div class="form-group">
                        <asp:Label ID="lblname" runat="server" Style="color:#323b44" Text="Teacher Name:"></asp:Label> 
                         &nbsp;
                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>        
                    </div>
                            <div class="form-group">
                                <asp:Label ID="lblfather" Style="color:#323b44" runat="server" Text="Father Name:"></asp:Label> 
                         &nbsp; &nbsp;
                         <asp:TextBox ID="txtfather" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                            <div class="form-group">
                        <asp:Label ID="lbldob" runat="server" Style="color:#323b44" Text="D.O.B.:"></asp:Label> 
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:TextBox ID="txtdob" runat="server" CssClass="form-control date"></asp:TextBox> 
                        
                    </div>
                            <div class="form-group"><asp:Label ID="lblphone" Style="color:#323b44" runat="server" Text="Phone No.:"></asp:Label> 
                         &nbsp; &nbsp; &nbsp; &nbsp;
                         <asp:TextBox ID="txtphone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                             <div class="form-group">
                        <asp:Label ID="lbladdress" runat="server" Style="color:#323b44" Text="Address:"></asp:Label> 
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
                        <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                           <div class="form-group"><asp:Label ID="lblemail" Style="color:#323b44" runat="server" Text="Email Address:"></asp:Label> 
                         &nbsp; 
                         <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Panel ID="pnladmin" Visible="false" runat="server">
                            <div class="form-group"><asp:Label ID="lblfranchisee" Style="color:#323b44" runat="server" Text="Franchisee:"></asp:Label> 
                         &nbsp; 
                         <asp:DropDownList ID="ddlcode" runat="server" CssClass="form-control" Width="120px">
                         </asp:DropDownList>
                    </div>
                    </asp:Panel>
                  
                           <div class="form-group">
                         <asp:Button ID="btnaddteacher" CssClass="btn btn-success" runat="server" Text="Submit" 
                              Height="30px" Width="70px" onclick="btnaddteacher_Click" /> 
             <%--            <asp:Button ID="btnreset5" runat="server" CssClass="fv" 
                              Height="30px" Text="Reset" onclick="btnreset5_Click"/>--%>
                 </div>
                  
          
  </asp:Panel>
 <br />

 <asp:Panel ID="pnlGrade" Visible="false" CssClass="pnlstyle box1 effect7" runat="server">

     <div class="panel panel-success">
  <div class="panel-heading">
    <h3 class="panel-title">Grade</h3>
  </div>
  <div class="panel-body">
    <div class="form-group">
        <label>Select Center</label>
        <asp:DropDownList ID="ddlCenter" CssClass=" form-control" runat="server">
     <asp:ListItem>--Select Center--</asp:ListItem>
    <asp:ListItem>abc</asp:ListItem>
    <asp:ListItem>ABC</asp:ListItem>
    </asp:DropDownList>
    </div>
      <div class="form-group">
          <label>Minimum Percentage</label>
          <asp:TextBox ID="txtMinPerc" CssClass=" form-control" runat="server"></asp:TextBox>
      </div>
      <div class="form-group">
          <label>Maximum Percentage</label>
          <asp:TextBox ID="txtMaxPerc" CssClass=" form-control" runat="server"></asp:TextBox>
      </div>
      <div class="form-group">
          <label>Grade</label>
          <asp:TextBox ID="txtgrde" CssClass=" form-control" runat="server"></asp:TextBox>
      </div>
      <div class="form-group">
          <asp:Button ID="btnGrade" CssClass="btn btn-success" runat="server" Text="Submit"  OnClientClick="return ValidateForm4()" 
        onclick="btnGrade_Click" /> 
      </div>
  </div>
</div>

</asp:Panel>
<div class="clearfix"></div>

        <asp:Panel ID="pnlfanch" runat="server" CssClass="pop" Visible="false">
            <h4>Select Franchisee</h4>
            <hr />
            <asp:DropDownList ID="ddlfanch" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnsubmited" runat="server" Text="Submit" 
                onclick="btnsubmited_Click" />
            <asp:Button ID="btncncl" runat="server" Text="Cancel" />
        </asp:Panel>

        <asp:HiddenField ID="btnhidden" runat="server" />
    </div>
    <div class="col-md-4">
        <ul class="list-group">
          <li class="list-group-item text-center" aria-disabled="true"><b>Setting</b> </li>
          <li class="list-group-item"><asp:LinkButton ID="addcategory"   runat="server"  onclick="addcategory_Click" >Room List</asp:LinkButton></li>
          <li class="list-group-item"><asp:LinkButton ID="viewcourse"   runat="server" onclick="LinkButton2_Click">Course List</asp:LinkButton></li>
          <li class="list-group-item"><asp:LinkButton ID="viewbatch" runat="server"  onclick="viewbatch_Click" >Batch List</asp:LinkButton></li>
          <li class="list-group-item"><asp:LinkButton ID="lnkteacher" runat="server" Visible="false"  onclick="lnkteacher_Click" >View Teacher</asp:LinkButton></li>
         <li class="list-group-item"><asp:LinkButton ID="viewgrade" runat="server" Visible="false" onclick="viewgrade_Click" >View Grade</asp:LinkButton></li>
         </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
     <script type="text/javascript">
               // When the document is ready
               $(document).ready(function () {

                   $('.date').datepicker({
                       format: "dd/mm/yyyy"
                   });

               });
    </script>
</asp:Content>

