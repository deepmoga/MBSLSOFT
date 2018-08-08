<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="ReceptionDetails.aspx.cs" Inherits="Auth_ReceptionDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Reception Registration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
  
   <div class="col-md-8">
       

       <div class="form-group">
               <label>Date</label>
              <asp:TextBox ID="txtdate" required runat="server" CssClass="form-control"></asp:TextBox>


           <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></asp:CalendarExtender>
       </div>
       <div class="form-group">
               <label>Name</label>
           <asp:DropDownList ID="ddltype" CssClass="form-control" runat="server">
               <asp:ListItem>Select Type</asp:ListItem>
               <asp:ListItem>Admin</asp:ListItem>
               <asp:ListItem>Receptionist</asp:ListItem>
           </asp:DropDownList>
         </div>
        <div class="form-group">
               <label>Name</label>
              <asp:TextBox ID="txtname" required runat="server" CssClass="form-control"></asp:TextBox>
         </div>
    <div class="form-group">
             <label>Date Of Birth</label>
              <asp:TextBox ID="txtdob" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob" PopupButtonID="txtdob" CssClass="cal" Format="dd/MM/yyyy">
        </asp:CalendarExtender>

    </div>
    <div class="form-group">
                <label>Father's Name</label>
               <asp:TextBox ID="txtfather" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
                 <label>Mother's Name</label>
                <asp:TextBox ID="txtmother" runat="server" CssClass="form-control"></asp:TextBox>
   </div>
    <div class="form-group">
                 <label>Address</label>
                <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
                 <label>Email</label>
                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     ControlToValidate="txtemail" ErrorMessage="Incorrect Format!" 
                     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                     ValidationGroup="grp1"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
                <label>Contact No.</label>
                <asp:TextBox ID="txtcontact" runat="server" CssClass="form-control"></asp:TextBox>
               <asp:CompareValidator ID="CompareValidator1" runat="server"   Operator="DataTypeCheck"
    Type="Integer"    ControlToValidate="txtcontact"    Text="Must be in numbers." />
    </div>
   <div class="form-group">
                <label>Login ID</label>
                <asp:TextBox ID="txtlogin" runat="server" CssClass="form-control"></asp:TextBox>
   </div>
   <div class="form-group">
                <label>Password</label>
                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control"
                    ></asp:TextBox>
   </div>
       <div class="form-group">
           <label>Image</label>
           <asp:FileUpload ID="FileUpload1" runat="server" />
       </div>
   
   <div style="text-align:right; padding-right:150px">
    <asp:Button ID="btnsubmit" runat="server" Text="Submit" onclick="btn1_Click" />
    <asp:Button ID="btnreset" runat="server" Text="Reset" onclick="btn2_Click" />
    </div>

</div>
    <div class="col-md-4">
        <h3>Assign Roles</h3>
        <hr />
        <asp:GridView ID="gvpage" CssClass="table table-bordered" OnRowDataBound="gvpage_RowDataBound" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                        <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="pname" HeaderText="Page Name" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

