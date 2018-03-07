<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="DeadLock.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var lblMessage = $('#Label1');
            var attemptsLeft;
            function updateData() {
                $.ajax({
                    url: 'WebForm2.aspx/CallStoredProcedure',
                    method: 'post',
                    contentType: 'application/json',
                    data: '{attemptsLeft:' + attemptsLeft + '}',
                    dataType: 'json',
                    success: function (data) {
                        lblMessage.text(data.d.Message);
                        attemptsLeft = data.d.AttemptsLeft;
                        if (data.d.Success) {
                            $('#btn').prop('disabled', false);
                            lblMessage.css('color', 'green');
                        }
                        else if (attemptsLeft > 0) {
                            lblMessage.css('color', 'red');
                            updateData();
                        }
                        else {
                            lblMessage.css('color', 'red');
                            lblMessage.text('Zero Attempt Left');
                        }
                    },
                    error: function (err) {
                        lblMessage.css('color', 'red');
                        lblMessage.text(err.responseText);
                    }
                });
            }

            $('#btn').click(function () {
                $(this).prop('disabled', true);
                lblMessage.text('Updating...');
                attemptsLeft = 5;
                updateData();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="btn" type="button" value="Update Table B and Update Table A" />
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
