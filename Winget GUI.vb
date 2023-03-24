Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Net.WebRequestMethods
Imports System.Reflection
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Text.Json

Public Class Form1
    Dim vInternet As String
    Private Sub BU_Search_Click(sender As Object, e As EventArgs) Handles BU_Search.Click
        If My.Computer.FileSystem.FileExists("WorkerFile.cmd") = True Then
            My.Computer.FileSystem.DeleteFile("WorkerFile.cmd")
        End If
        If My.Computer.FileSystem.FileExists("WorkerOutput.txt") = True Then
            My.Computer.FileSystem.DeleteFile("WorkerOutput.txt")
        End If

        LB_Search_Out.Items.Clear()
        Dim File As System.IO.StreamWriter
        File = My.Computer.FileSystem.OpenTextFileWriter("WorkerFile.cmd", True)
        File.WriteLine(" ")
        File.WriteLine("@Echo Off")
        File.WriteLine("CLS")
        File.WriteLine("Echo =========================================================")
        File.WriteLine("Echo WorkerFile Process - Search")
        File.WriteLine("Echo =========================================================")
        File.WriteLine("WINGET Search """ & TB_Search.Text & """>WorkerOutput.txt")
        File.Close()

        Dim myProcess As Process = New Process()
        myProcess.StartInfo.FileName = "cmd.exe"
        myProcess.StartInfo.Arguments = " /c WorkerFile.cmd"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        myProcess.StartInfo.LoadUserProfile = True
        myProcess.StartInfo.RedirectStandardError = True
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.Start()
        myProcess.WaitForExit()

        'Tidy up output seek for █ and ▒
        Dim FindLines() As String
        Dim outputlines As New List(Of String)
        Dim searchString1 As String = "█"
        Dim searchString2 As String = "▒"
        FindLines = System.IO.File.ReadAllLines("WorkerOutput.txt")

        For Each line As String In FindLines
            If line.Contains(searchString1) = False Then
                outputlines.Add(line)
            End If
            If line.Contains(searchString2) = False Then
                outputlines.Add(line)
            End If
        Next

        'Remove Line 1
        Dim TxtLines As List(Of String) = System.IO.File.ReadAllLines("WorkerOutput.txt").ToList
        TxtLines.RemoveAt(0)
        System.IO.File.WriteAllLines("WorkerOutput.txt", TxtLines)

        'Check for data
        'No package found matching input criteria.
        Dim FindText As String = System.IO.File.ReadAllText("WorkerOutput.txt")
        Dim index As Integer = FindText.IndexOf("No package found matching input criteria.")
        If index >= 0 Then
            MsgBox("No package found matching input criteria.")
            TB_Search.Text = ""
            LB_Search_Out.Visible = False
            BU_Add.Visible = False
        Else
            'Tidy up list
            LB_Search_Out.Visible = True
            BU_Add.Visible = True
            Dim myfile As String = "WorkerOutput.txt"
            Dim allLines As String() = System.IO.File.ReadAllLines(myfile)

            For Each line As String In allLines
                LB_Search_Out.Items.Add(line)
            Next
            LB_HeaderValue.Text = LB_Search_Out.Items(0)
            LB_Search_Out.Items.RemoveAt(0)
            LB_Search_Out.Items.RemoveAt(0)
        End If
        Cleanup()
    End Sub
    Private Sub BU_Add_Click(sender As Object, e As EventArgs) Handles BU_Add.Click
        LB_Manifest.Visible = True
        BU_Remove.Visible = True
        CB_lnk.Visible = True
        LB_Project.Visible = True
        TB_Filename.Visible = True
        BU_Build.Visible = True
        Dim SelectedItem As String = LB_Search_Out.SelectedItem.ToString
        Dim vName As String
        Dim vPayload As String
        Dim vHeader As String
        vHeader = LB_HeaderValue.Text
        Dim sIndex = vHeader.IndexOf("I")
        Dim eIndex = vHeader.IndexOf("V")
        Dim vLong = eIndex - sIndex

        'Trim out info for Description and Target Payload
        vPayload = SelectedItem
        vName = vPayload.Substring(0, sIndex - 1)
        vPayload = vPayload.Substring(sIndex, vLong)
        vPayload = vPayload.Replace(" ", "")
        ' MsgBox("Added " & vName & Chr(13) & "ID: " & vPayload & " to manifest")
        LB_SelectedName.Items.Add(vName)
        LB_SelectedID.Items.Add(vPayload)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BU_Build.Click
        If TB_Filename.Text = "" Then
            MsgBox("No Filename")
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(TB_Filename.Text & ".cmd") Then
            My.Computer.FileSystem.DeleteFile(TB_Filename.Text & ".cmd")
        End If
        If My.Computer.FileSystem.FileExists(TB_Filename.Text & ".manifest") Then
            My.Computer.FileSystem.DeleteFile(TB_Filename.Text & ".manifest")
        End If
        If My.Computer.FileSystem.FileExists(TB_Filename.Text & ".ids") Then
            My.Computer.FileSystem.DeleteFile(TB_Filename.Text & ".ids")
        End If


        Dim File As System.IO.StreamWriter
        File = My.Computer.FileSystem.OpenTextFileWriter(TB_Filename.Text & ".cmd", True)
        File.WriteLine(" ")
        File.WriteLine("@Echo Off")
        File.WriteLine("CLS")
        Dim i = 0
        For Each item As String In LB_SelectedName.Items
            i = i + 1
            Dim vPosition As String = LB_SelectedID.Items(i - 1)
            Dim vPositionName As String = LB_SelectedName.Items(i - 1)
            File.WriteLine("Echo =========================================================")
            File.WriteLine("Echo Winget Install - " & vPositionName)
            File.WriteLine("Echo =========================================================")
            File.WriteLine("WINGET Install """ & vPosition & """ --accept-package-agreements")
        Next
        If CB_lnk.Checked = True Then
            File.WriteLine("Del C:\Users\Public\*.lnk /Q /S")
            File.WriteLine("Del %USERS%\Desktop\*.lnk /Q /S")
        End If
        File.Close()

        Dim File2 As System.IO.StreamWriter
        File2 = My.Computer.FileSystem.OpenTextFileWriter(TB_Filename.Text & ".manifest", True)
        i = 0
        For Each item As String In LB_SelectedName.Items
            i = i + 1
            Dim vPositionName As String = LB_SelectedName.Items(i - 1)
            File2.WriteLine(vPositionName)
        Next
        File2.Close()
        Dim File3 As System.IO.StreamWriter
        File3 = My.Computer.FileSystem.OpenTextFileWriter(TB_Filename.Text & ".ids", True)
        i = 0
        For Each item As String In LB_SelectedID.Items
            i = i + 1
            Dim vPosition As String = LB_SelectedID.Items(i - 1)
            File3.WriteLine(vPosition)
        Next
        File3.Close()

        MsgBox(TB_Filename.Text & ".cmd is ready")
        Dim path As String = Directory.GetCurrentDirectory()
        Process.Start("explorer.exe", path)
        Cleanup()
        TB_Filename.Text = ""
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cleanup()
        'If My.Computer.Network.Ping("www.bing.com") = "True" Then
        '    Dim wc As New WebClient
        '    Dim xmlText As String = wc.DownloadString("https://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=en-US")
        '    System.IO.File.WriteAllText("Wallpaper.xml", xmlText)

        '    Dim edtConfig = XDocument.Load("Wallpaper.xml")

        '    Dim vWallpaper As String = <url><%= From ReadEDT In edtConfig.<images>.<image> Select ReadEDT.<url>.Value %></url>
        '    Dim FullURL As String = "https://www.bing.com" & vWallpaper
        '    DownloadFile(FullURL, "Wallpaper.jpeg")

        '    Dim id As String = "Wallpaper"
        '    Dim folder As String = ""
        '    Dim filename As String = System.IO.Path.Combine(folder, id & ".jpeg")
        '    Try
        '        Using fs As New System.IO.FileStream(filename, IO.FileMode.Open)
        '            PictureBox1.Image = New Bitmap(Image.FromStream(fs))
        '            PictureBox1.BackgroundImageLayout = PictureBoxSizeMode.Zoom

        '        End Using
        '    Catch ex As Exception
        '        Dim msg As String = "Filename: " & filename &
        '        Environment.NewLine & Environment.NewLine &
        '        "Exception: " & ex.ToString
        '        MessageBox.Show(msg, "Error Opening Image File")
        '    End Try
        'End If

    End Sub
    Sub Cleanup()
        If My.Computer.FileSystem.FileExists("WorkerFile.cmd") = True Then
            My.Computer.FileSystem.DeleteFile("WorkerFile.cmd")
        End If
        If My.Computer.FileSystem.FileExists("WorkerOutput.txt") = True Then
            My.Computer.FileSystem.DeleteFile("WorkerOutput.txt")
        End If
        If My.Computer.FileSystem.FileExists("Wallpaper.xml") = True Then
            My.Computer.FileSystem.DeleteFile("Wallpaper.xml")
        End If
        If My.Computer.FileSystem.FileExists("Wallpaper.jpeg") = True Then
            My.Computer.FileSystem.DeleteFile("Wallpaper.jpeg")
        End If
    End Sub
    Private Sub BU_Remove_Click(sender As Object, e As EventArgs) Handles BU_Remove.Click
        Dim listIndex As Integer = LB_SelectedName.SelectedIndex


        If listIndex = -1 Then
            LB_Project.Visible = False
            TB_Filename.Visible = False
            BU_Build.Visible = False
            CB_lnk.Visible = False
            BU_Remove.Visible = False
            Exit Sub
        End If
        LB_SelectedName.Items.RemoveAt(listIndex)
        LB_SelectedID.Items.RemoveAt(listIndex)

        If LB_SelectedName.Items.Count = 0 Then
            LB_Project.Visible = False
            TB_Filename.Visible = False
            BU_Build.Visible = False
            CB_lnk.Visible = False
            LB_Manifest.Visible = False
            BU_Remove.Visible = False
        End If
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        LB_Search_Out.Items.Clear()
        LB_SelectedName.Items.Clear()
        LB_SelectedID.Items.Clear()
        TB_Search.Text = ""
        OFD_Manifest.Title = "Please Select .manifest File"
        OFD_Manifest.Filter = "Manifest File|*.manifest"
        If OFD_Manifest.ShowDialog = DialogResult.OK Then


            Dim myfile As String = OFD_Manifest.FileName
            Dim allLines As String() = System.IO.File.ReadAllLines(myfile)
            TB_Filename.Text = myfile.Replace(".manifest", "")
            For Each line As String In allLines
                LB_SelectedName.Items.Add(line).ToString()
            Next
            Dim FileIDs As String = myfile.Replace(".manifest", ".ids")
            Dim myfile2 As String = FileIDs
            Dim allLines2 As String() = System.IO.File.ReadAllLines(myfile2)
            For Each line As String In allLines2
                LB_SelectedID.Items.Add(line).ToString()
            Next
        End If
        LB_Search_Out.Visible = False
        BU_Add.Visible = False
        LB_Project.Visible = True
        TB_Filename.Visible = True
        BU_Build.Visible = True
        BU_Remove.Visible = True
        LB_Manifest.Visible = True
        CB_lnk.Visible = True
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        LB_Manifest.Visible = False
        BU_Remove.Visible = False
        LB_Search_Out.Visible = False
        BU_Add.Visible = False
        BU_Remove.Visible = False
        LB_Search_Out.Items.Clear()
        LB_SelectedName.Items.Clear()
        LB_SelectedID.Items.Clear()
        TB_Search.Text = ""
    End Sub
    Private Declare Function URLDownloadToFile Lib "urlmon" Alias "URLDownloadToFileA" (ByVal pCaller As Long, ByVal szURL As String, ByVal szFileName As String, ByVal dwReserved As Long, ByVal lpfnCB As Long) As Long
    Public Function DownloadFile(URL As String, LocalFilename As String) As Boolean
        DownloadFile = (URLDownloadToFile(0, URL, LocalFilename, 0, 0) = 0)
    End Function
    Private Sub TB_Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Search.KeyPress
        If e.KeyChar = Chr(13) Then 'Chr(13) is the Enter Key
            BU_Search_Click(Me, EventArgs.Empty)
            e.Handled = True
        End If
        If e.KeyChar = Chr(27) Then
            TB_Search.Text = ""
            LB_Search_Out.Items.Clear()
            LB_Search_Out.Visible = False
            BU_Add.Visible = False
            e.Handled = True
        End If
    End Sub
    Private Sub TB_Filename_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Filename.KeyPress
        If e.KeyChar = Chr(13) Then 'Chr(13) is the Enter Key
            Button1_Click(Me, EventArgs.Empty)
            e.Handled = True

        End If
    End Sub
End Class
