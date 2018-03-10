<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="DeadLock.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
                <asp:Button ID="btnFillDummyData" runat="server" Text="Fill with data" OnClick="btnFillDummyData_Click" /><br />
            <table>
                <tbody>
                    <tr>
                        <td>Id:
                          <asp:TextBox ID="txtId1" runat="server"></asp:TextBox>
                        </td>
                        <td>Name:
                          <asp:TextBox ID="txtName1" runat="server"></asp:TextBox>
                        </td>
                        <td>Address:
                          <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Id:
                            <asp:TextBox ID="txtId2" runat="server"></asp:TextBox>
                        </td>
                        <td>Name:
                             <asp:TextBox ID="txtName2" runat="server"></asp:TextBox>
                        </td>
                        <td>Address:
        <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Id:
        <asp:TextBox ID="txtId3" runat="server"></asp:TextBox>

                        </td>
                        <td>Name:
        <asp:TextBox ID="txtName3" runat="server"></asp:TextBox>

                        </td>
                        <td>Address:
       <asp:TextBox ID="txtAddress3" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                </tbody>
            </table>

        


        </div>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Save Datatable" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>
