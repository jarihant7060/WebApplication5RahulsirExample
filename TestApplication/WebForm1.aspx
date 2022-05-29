<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="WebApplication5RahulsirExample.TestApplication.WebForm1" %>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <h1>Your content</h1>
    <div id="dvGrid" style="padding: 10px; width: 616px">

        <contenttemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                DataKeyNames="Id,Name,Country" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" AllowPaging="true"
                OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
                Width="450">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="false" />
                   <%-- <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />--%>

                    <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCountry" runat="server" Text='<%# Eval("Country") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>


            </asp:GridView>
            <asp:Button runat="server" Text="save" ID="btnsave"  OnClick="BtnOnClick" BorderStyle="Solid" Width="153px" />
        </contenttemplate>

    </div>
</asp:Content>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- CSS only -->
</head>
<body>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <div class="Container">
        <div class="sub-container">
            <section class="section1">
                <div class="container-class">
                    <div class="row">
                        <div class="col-10">
                        </div>
                        <div class="col-2 row markscolumn">
                            <div class="col">
                                Marks: 100
                            </div>
                            
                        </div>
                    </div>
                </div>
            </section>
            <section class="section2">
                <div class="container-class">
                    <div class="row">
                        <div>
                            <%--<form id="form1" runat="server">
                                <div id="tablediv">
                                    <table class="studentTable" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Class</th>
                                                <th>Address</th>
                                                <th>TotalMarks</th>
                                                <th>Percentage</th>
                                                <th>CGPA</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><label id="lblName" class="">Arihant</label></td>
                                                <td><asp:TextBox runat="server" ID="txtClass"></asp:TextBox></td>
                                                <td><asp:TextBox runat="server" ID="txtAddress"></asp:TextBox></td>
                                                <td><asp:TextBox runat="server" ID="txtMarks"></asp:TextBox></td>
                                                <td><asp:TextBox runat="server" ID="txtPercentage"></asp:TextBox></td>
                                                <td><asp:TextBox runat="server" ID="txtCGPA"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div id="divbuttons">
                                    <asp:Button runet="server" Text="Save"/>
                                    <asp:Button runet="server" Text="Edit"/>
                                    <asp:Button runet="server" Text="Save"/>
                                </div>
                            </form>--%>

<%--  <div id="dvGrid" style="padding: 10px; width: 450px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
            DataKeyNames="CustomerId" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" PageSize = "3" AllowPaging ="true" 
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added."
            Width="450">
            <Columns>
                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCountry" runat="server" Text='<%# Eval("Country") %>' Width="140"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                    ItemStyle-Width="150" />
            </Columns>
        </asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td style="width: 150px">
                    Name:<br />
                    <asp:TextBox ID="txtName" runat="server" Width="140" />
                </td>
                <td style="width: 150px">
                    Country:<br />
                    <asp:TextBox ID="txtCountry" runat="server" Width="140" />
                </td>
                <td style="width: 150px">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</div>--%>
<%--                 </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</body>
</html>--%>