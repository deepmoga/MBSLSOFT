<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/profile.master" AutoEventWireup="true" CodeFile="student-Profile.aspx.cs" Inherits="Auth_student_Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Basic Info
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <asp:Label ID="lblcode" runat="server" Text=""></asp:Label>
    <div style="float: right;">
        <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btndeactive" runat="server" Text="Deactivate" CssClass="btn btn-danger"
            OnClick="btndeactive_Click" />
        <asp:Button ID="btnactive" runat="server" Text="Activate" CssClass="btn btn-success"
            OnClick="btnactive_Click" />
    </div>

    <div class="col-lg-12">
        <div class="col-md-8">

            <div class=" form-group">
                <div class="col-md-3">
                    Name:  
                </div>
                <div class="col-md-9">

                    <asp:TextBox ID="txtName" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Roll No:
                </div>
                <div class="col-md-9">

                    <asp:TextBox ID="txtRollNo" CssClass="form-control" Text="" ReadOnly="True" runat="server" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class=" form-group" style="display: none">
                <div class="col-md-3">
                    Old Roll No:
                </div>
                <div class="col-md-9">

                    <asp:TextBox ID="txtOldRollNo" CssClass="form-control" Text="" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class=" form-group">
                <div class="col-md-3">
                    DOB: 
                </div>
                <div class="col-md-9">

                    <asp:TextBox ID="txtDOB" placeholder="DD/MM/YYYY" CssClass="form-control" runat="server" Enabled="false" />

                    <ajaxToolkit:CalendarExtender ID="txtDOB_CalendarExtender" Format="dd/MM/yyyy" Enabled="True"
                        runat="server" BehaviorID="txtDOB_CalendarExtender" TargetControlID="txtDOB"></ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Father's Name:
                </div>
                <div class="col-md-9">
                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtFthrName" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Address
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtaddress" runat="server" Enabled="false" />
                </div>
            </div>


            <div class=" form-group">
                <div class="col-md-3">
                    Phone
                </div>
                <div class="col-md-9">

                    <asp:TextBox placeholder="" ID="txtphn" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Father Phone 
                </div>
                <div class="col-md-9">

                    <asp:TextBox placeholder="" ID="txtfphn" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Mother Tongue  
                </div>
                <div class="col-md-9">

                    <asp:TextBox placeholder="" ID="txtlang" TextMode="MultiLine" CssClass="form-control" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    +2
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtContactNumber" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Institute Name
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtinst" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    qualification
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtquali" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Type
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtHomePhone" runat="server" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Reffered By
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtreff" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Room Type
                </div>
                <div class="col-md-9">

                    <asp:DropDownList ID="ddlroom" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    User Name
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtuser" runat="server" Enabled="false" />
                </div>
            </div>
            <div class=" form-group">
                <div class="col-md-3">
                    Password
                </div>
                <div class="col-md-9">

                    <asp:TextBox CssClass="form-control" placeholder="" ID="txtpassword" runat="server" Enabled="false" />
                </div>
            </div>


            <div class=" form-group">

                <asp:Button ID="btnSave" CssClass="btn" runat="server" Style="width: 80px"
                    Text="Save" OnClick="btnSave_Click" Visible="False" />
                <asp:Button ID="btnCancelProfile" CssClass="btn" Style="width: 80px"
                    runat="server" Text="Cancel"
                    OnClick="btnCancelProfile_Click" Visible="False" />
            </div>
        </div>
        <div class="col-md-4">
            <%--<img src='../uploadimage/<%=img %>' alt="" class=" thumbnail img-responsive" />--%>
            <asp:Image ID="ImgPrv" Width="150px" Height="150px" style="overflow:hidden" CssClass="thumbnail" runat="server" />
            <asp:FileUpload ID="FileStudentPic" Visible="false" runat="server" onchange="ShowImagePreview(this);" />

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</asp:Content>

