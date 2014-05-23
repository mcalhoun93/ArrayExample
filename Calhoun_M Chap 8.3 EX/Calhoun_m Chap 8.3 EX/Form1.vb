Public Class TicketSales

    'Private totmezdecimal, totodecimal, totgdecimal, totbaldecimal, totsaledecimal As Decimal
    'Private totmeztic, tototic, totgtic, totbaltic As Integer
    Private totalsalesdecimal(3) As Decimal
    Private amountsoldinteger(3) As Integer
    Private pricedecimal() As Decimal = {40D, 27.5D, 15D, 10D}

    Private Sub ShowPricesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowPricesToolStripMenuItem.Click

        TicketPrices.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub TotalSalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalSalesReportToolStripMenuItem.Click

        Dim messagestring As String = String.Empty
        Dim sectionstring As String

        For sectioninteger As Integer = 0 To 3

            sectionstring = ListBox1.Items(sectioninteger) & " (" & pricedecimal(sectioninteger).ToString("C") & " per ticket): " & _
                           amountsoldinteger(sectioninteger) & " sold " & totalsalesdecimal(sectioninteger).ToString("C") & _
                           Environment.NewLine & Environment.NewLine

            messagestring += sectionstring
        Next

        MessageBox.Show(messagestring, "Sales Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)



    End Sub

    Private Sub ClearSelectionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSelectionsToolStripMenuItem.Click

        amtduetxtbox.Clear()
        tixtxtbox.Clear()
        ListBox1.SelectedIndex = -1

    End Sub

    Private Sub PurchaseTicketsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseTicketsToolStripMenuItem.Click

        Dim numbertixinteger, indexinteger As Integer
        Dim totaldecimal As Decimal

        If ListBox1.SelectedIndex <> -1 Then

            Try
                numbertixinteger = Integer.Parse(tixtxtbox.Text)
            Catch ex As Exception
                MessageBox.Show("Please Enter a Valid Number of Tickets.", "Data Entry Error", _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                With tixtxtbox
                    .Focus()
                    .SelectAll()
                End With

            End Try

            indexinteger = ListBox1.SelectedIndex
            totaldecimal = pricedecimal(indexinteger) * numbertixinteger

            amtduetxtbox.Text = totaldecimal.ToString("C")

            totalsalesdecimal(indexinteger) += totaldecimal
            amountsoldinteger(indexinteger) += numbertixinteger

        Else
            MessageBox.Show("Please Select a Seating Section.", "Data Entry Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub
End Class
