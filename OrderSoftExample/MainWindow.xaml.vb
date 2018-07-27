Imports OrderSoft

Class MainWindow
    Dim client As New OSClient()

    Private Async Sub connect_onclick(sender As Object, e As RoutedEventArgs) Handles btnConnect.Click
        ' Set IP UI elements as disabled while loading
        lblIP.IsEnabled = False
        txtIP.IsEnabled = False
        btnConnect.IsEnabled = False

        Dim failed = False
        Try
            ' Initiate client with given IP
            Await client.init(txtIP.Text)
        Catch ex As Exception
            ' Error was thrown during initialisation
            failed = True
            MessageBox.Show(ex.ToString, "An error occurred while connecting")
        End Try

        If failed Then
            ' Re-enable connection UI elements to allow retry
            lblIP.IsEnabled = True
            txtIP.IsEnabled = True
            btnConnect.IsEnabled = True
        Else
            ' Enable login options for next state
            lblUser.IsEnabled = True
            lblPassword.IsEnabled = True
            txtUser.IsEnabled = True
            txtPassword.IsEnabled = True

            btnLogin.IsEnabled = True
        End If
    End Sub

    Private Async Sub login_onclick(sender As Object, e As RoutedEventArgs) Handles btnLogin.Click
        ' Disable login UI elements while interacting with server
        lblUser.IsEnabled = False
        lblPassword.IsEnabled = False
        txtUser.IsEnabled = False
        txtPassword.IsEnabled = False
        btnLogin.IsEnabled = False

        Dim failed = False
        Try
            Await client.login(txtUser.Text, txtPassword.Password)
        Catch ex As Exception
            failed = True
            MessageBox.Show(ex.ToString, "Error while logging in")
        End Try

        If failed Then
            ' Re-enable login options
            lblUser.IsEnabled = True
            lblPassword.IsEnabled = True
            txtUser.IsEnabled = True
            txtPassword.IsEnabled = True

            btnLogin.IsEnabled = True
        Else
            itWorks.Visibility = Visibility.Visible
        End If
    End Sub
End Class
