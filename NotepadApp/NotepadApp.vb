'*********************************'
'  Notepad 10k - a Notepad Clone  '
'          Author: Ian P          '
'  Description: A notepad clone.  '
'        Date: August 2011        '
'*********************************'

'Imports are things that we get from the .NET framework. By importing the packages we need, we will use less code
'later on if we use something repeatedly. For example, by importing System.Drawing.Printing, we can just use the code
'PrintDocument() instead of System.Drawing.Printing.PrintDocument(). They are placed before everything else in the code.
'VB.NET will usually tell you what you need to import as you enter code so you do not need to remember absolutely everything.

Imports System.IO                       'Used for file operations (appending text/etc)
Imports System.DateTime                 'Used for date/time
Imports System.Environment              'Used for special folders (i.e.: Desktop, My Documents, etc.)
Imports System.Drawing.Printing         'Used for printing, specifically the Page Setup dialog.
Imports System.Windows.Forms.Clipboard  'Used for clipboard operations (Cut/Copy/Paste)

Public Class NotepadApp

    'These are variables that are declared from the start of the program. They could be declared elsewhere in the
    'program, but this a neater way of organizing your program as well as a quick way to find variables if you need
    'to change them instead of searching the entire program. They could be in a separate class as well.
    Private FontWindow As New FontDialog
    Private OpenWindow As New OpenFileDialog
    Private SaveWindow As New SaveFileDialog
    Private PrintWindow As New PrintDialog
    Private PageSetupWindow As New PageSetupDialog
    Private PrintPreviewWindow As New PrintPreviewDialog

    Private TitleText As String
    Private CurrentFile, CurrentPath As String
    Private UndoState, RedoState As String

    Private FileHasBeenSaved As Boolean

    Private Function SetTitleText()
        'Set the title text of the app to 
        TitleText = CurrentFile & " - Notepad 10k"
        'Finally set the title text.
        Me.Text = TitleText
        Return True 'This gets rid of a warning.
    End Function

    Private Function SaveAs()
        'A function is used when you need to return a value such as Sum(2 + 3) or need to call a piece of code more than once.
        'In this case, our SaveAs code is a function because we not only need to call it under the 'Save As' option but also
        'if the file has never been saved and the user chooses Save instead of Save As.

        'Show the save window that was declared at the start of the program.
        Try
            With SaveWindow
                'Some default settings we want to add.
                .DefaultExt = ".txt"    'Default extension
                .Filter = "All files (*.*)|*.*|Rich-text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt"  'Shown formats
                .FilterIndex = 3    'Default file format choice; in this case .txt
                .InitialDirectory = SpecialFolder.MyDocuments   'default directory
                .FileName = "untitled.txt"  'default file name
            End With

            If SaveWindow.ShowDialog() = DialogResult.OK Then
                'If the user presses OK, save the text to file.
                File.WriteAllText(SaveWindow.FileName, txtNotepad.Text)
                'Get JUST the file name and its extension.
                CurrentFile = Path.GetFileName(SaveWindow.FileName)
                'Save the path for later usage.
                CurrentPath = SaveWindow.FileName
                'Set the titlebar text
                SetTitleText()
                'We need to toggle the FileHasBeenSaved variable to true since it's now been saved.
                FileHasBeenSaved = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
        Return Nothing
    End Function

    Private Sub NotepadApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'The load event is where anything we want to happen when the form is loaded goes. Variable setting and 
        'control parameters can be set here before the user can use the form.

        'Set the Word Wrap option to be checked under the options menu. Since the textbox is already set to have the
        'text word-wrap, we do not need to set that here, but it could be set here using txtNotepad.WordWrap = True.
        WordWrapToolStripMenuItem.Checked = True

        'Set the CurrentFile as 'Untitled' since it has no file associated with it.
        CurrentFile = "Untitled"

        'Call the function that sets the program's title text. The word 'Call' is optional.
        Call SetTitleText()

        'We need to keep track of if the file has been saved so we can later tell the save option if it should just save over
        'the previous file or if it needs to save the text to a file. We can use a Boolean (true/false statement) for this.
        FileHasBeenSaved = False
    End Sub

    Private Sub NotepadApp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'This will ask the user if they are sure they want to close the application. This is called when they click the "X" button.
        e.Cancel = MessageBox.Show("You may have made changes to the file " & CurrentFile & ". Please " & _
                                                    "make sure you have saved the file. Click 'Yes' if you HAVE saved the " & _
                                                    "file and would like to exit. Otherwise, click 'No' and go back and save the file " & _
                                                    "or continue working on it.", "Really exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) <> Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordWrapToolStripMenuItem.Click
        'This will toggle the 'word wrap' option in the Options menu and its related variable and apply the change.
        If WordWrapToolStripMenuItem.Checked = False Then
            WordWrapToolStripMenuItem.Checked = True
            txtNotepad.WordWrap = True
        Else
            WordWrapToolStripMenuItem.Checked = False
            txtNotepad.WordWrap = False
        End If
    End Sub

    Private Sub FontSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontSettingsToolStripMenuItem.Click
        'This is a rather simple way to change the font. An alternative would be to make your own font settings window
        'and then handle font changing of the textbox via the 'OK' button there.
        Try
            'First of all, we must open the font window we declared at the start of the program.
            FontWindow.ShowDialog()
            'After the user selects a font, we want to apply it to the textbox.
            txtNotepad.Font = FontWindow.Font
        Catch ex As Exception
            'We want to use a 'Try' statement to handle errors here in case the user selects a font combination that would
            'normally cause an error and cause the program to hang. Instead, we tell the user that there has been an error
            'and tell them what it is. A common error in this program would be TrueType fonts.
            MessageBox.Show(ex.Message, "Error")
        End Try

    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        'Show the print window that we declared at the start of the program.
        PrintWindow.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'This will ask the user if they would like to save their changes upon closing the program.
        'For the meantime, it does not check if the file has been edited since the last save so it will always ask the
        'user if they would like to exit.

        'We are using Dim here instead of putting it as a variable at the top of the class because it is only need here and
        'we want its messagebox to show something specific. It can be re-declared elsewhere if needed.
        Dim reply As DialogResult = MessageBox.Show("You may have made changes to the file " & CurrentFile & ". Please " & _
                                                    "make sure you have saved the file. Click 'Yes' if you HAVE saved the " & _
                                                    "file and would like to exit. Otherwise, click 'No' and go back and save the file " & _
                                                    "or continue working on it.", "Really exit?", _
              MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            'Close the program if we are not doing anything else.
            End
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            With OpenWindow
                'Some default settings we want to add.
                .Filter = "All files (*.*)|*.*|Rich-text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt"  'Shown formats
                .FilterIndex = 3    'Default file format choice; in this case .txt
                .Multiselect = False    'We don't really have a way to handle multi-file selections (yet) so disable it.
                .InitialDirectory = SpecialFolder.MyDocuments   'default directory
            End With

            If OpenWindow.ShowDialog() = DialogResult.OK Then
                'If the user presses OK, read the text from file.
                'Declare a stream reader variable.
                Dim textFile As StreamReader
                'Read the text from the chosen file.
                textFile = File.OpenText(OpenWindow.FileName)
                'Put the chosen file's text into the textbox.
                txtNotepad.Text = textFile.ReadToEnd()
                'Close the stream reader.
                textFile.Close()
                'Get JUST the file name and its extension.
                CurrentFile = Path.GetFileName(OpenWindow.FileName)
                'Save the path for later usage.
                CurrentPath = OpenWindow.FileName
                'Set the titlebar text
                SetTitleText()
                'We need to toggle the FileHasBeenSaved variable to true since been saved previously.
                FileHasBeenSaved = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        'Call the SaveAs function to save.
        SaveAs()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        'Create the Page Setup dialog. This line is required to show the dialog.
        PageSetupWindow.Document = New PrintDocument
        'Any settings we want to set for the user ourselves. For example, non-colour printing.
        PageSetupWindow.Document.DefaultPageSettings.Color = False
        'Show the page setup window that was declared at the start of the program.
        PageSetupWindow.ShowDialog()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        'Set the document to the one that's open.
        'PrintPreviewWindow.Document = txtNotepad.Text
        'Show the print preview window that was declared at the start of the program.
        PrintPreviewWindow.ShowDialog()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        'Select all the text in the textbox.
        txtNotepad.SelectionStart = 0
        txtNotepad.SelectionLength = txtNotepad.Text.Length
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Try
            'This If statement prevents an error from occuring if the user has not selected any text. An alternative would be
            'to disable the option from the Edit menu when there is no selected text. Either way works.
            If txtNotepad.SelectedText <> "" Then   'The <> operator means 'doesn't equal'
                'Copy the selected text to our computer's clipboard.
                SetText(txtNotepad.SelectedText)
                'Remove the selected text as we are cutting not copying. Using the word Nothing is the same as "".
                txtNotepad.SelectedText = Nothing
            Else
                'Since there's nothing selected we do nothing. The 'Else' section of this If statement exists solely for
                'education purposes and is not required to prevent the program from crashing; it will just skip it.
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        'This If statement prevents an error from occuring if the user has not selected any text. An alternative would be
        'to disable the option from the Edit menu when there is no selected text. Either way works.
        If txtNotepad.SelectedText <> "" Then   'The <> operator means 'doesn't equal'
            'Copy the selected text to our computer's clipboard.
            SetText(txtNotepad.SelectedText)
        Else
            'Since there's nothing selected we do nothing. The 'Else' section of this If statement exists solely for
            'education purposes and is not required to prevent the program from crashing; it will just skip it.
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        'This line of code will paste the text from the clipboard into the textbox.
        txtNotepad.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        txtNotepad.Undo()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            'The first check we want to do is to see if the file has ever been saved or if it's a new document. There are
            'a few ways we could do this; seeing if the file is still called "Untitled" with no extension (which would cause
            'a conflict if the user has a file with no extension called "Untitled"), or we could also use a Boolean (true/false
            'statement) to keep track of it from the start of the program until now.
            If FileHasBeenSaved = True Then
                'Since we are just saving over the old file, we don't need to open the dialog.
                'The StreamWriter is another to write text to a file. It is easier to use in this situation.
                Dim objWriter As New StreamWriter(CurrentPath)
                'Write the text OVER the previous text in the file.
                objWriter.Write(txtNotepad.Text)
                'Close the StreamWriter.
                objWriter.Close()
                'Dispose of the StreamWriter
                objWriter.Dispose()

                'Debug.Print can be used to output variables and other information to the Immediate Window. This allows you
                'to debug problems much more easily because you can view the value of variables. In this case we want to know
                'the path where the file is being saved.
                Debug.Print(CurrentPath)
            Else
                'Since the file has never been saved, we need to prompt the user to save the file so we call 'SaveAs'.
                SaveAs()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        'The New option should first prompt the user to save any changes to the open file, and then prepare a blank file for
        'them. We could simply close and reopen the program for them instead of resetting everything, but resetting variables
        'and such should be much faster in case something has happened to the executable somehow. We can also preserve their
        'settings this way.


        'We are using Dim here instead of putting it as a variable at the top of the class because it is only need here and
        'we want its messagebox to show something specific. It can be re-declared elsewhere if needed.
        Dim reply As DialogResult = MessageBox.Show("Do you really want to start a new document? Any unsaved changes will " & _
                                                    "be lost!", "Create new document?", _
              MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        If reply = DialogResult.Yes Then
            'Set the CurrentFile as 'Untitled' since it has no file associated with it.
            CurrentFile = "Untitled"

            'Call the function that sets the program's title text. The word 'Call' is optional.
            Call SetTitleText()

            'We need to keep track of if the file has been saved so we can later tell the save option if it should just save over
            'the previous file or if it needs to save the text to a file. We can use a Boolean (true/false statement) for this.
            'Since it's a new document, it has not been saved yet.
            FileHasBeenSaved = False

            'We should also clear the textbox for them. We could also add options such as "New from Current" or "New from Clipboard"
            'if we wanted to, in which case we would not clear the textbox or replace the text with the clipboard text, respectively.
            txtNotepad.Text = Nothing
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            'This If statement prevents an error from occuring if the user has not selected any text. An alternative would be
            'to disable the option from the Edit menu when there is no selected text. Either way works.
            If txtNotepad.SelectedText <> "" Then   'The <> operator means 'doesn't equal'
                'Remove the selected text as we not cutting or copying. Using the word Nothing is the same as "".
                txtNotepad.SelectedText = Nothing
            Else
                'Since there's nothing selected we do nothing. The 'Else' section of this If statement exists solely for
                'education purposes and is not required to prevent the program from crashing; it will just skip it.
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub TimeDayToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TimeDayToolStripMenuItem.Click
        'InsertTimeDate.Show()

        'Get the current date/time and insert it at the current selected point
        'txtNotepad.Text.Insert(txtNotepad.SelectionStart, (Now().ToString("hh:mm tt M/d/yyyy")))

        Dim insertText = (Now().ToString("h:mmtt M/d/yyyy"))
        Dim insertPos As Integer = txtNotepad.SelectionStart
        txtNotepad.Text = txtNotepad.Text.Insert(insertPos, insertText)
        txtNotepad.SelectionStart = insertPos + insertText.Length
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Created by ippavlin. The source code of this program is about 10KB without comments, or 21KB with them. It was created from August 6th-9th, 2011.", "About Notepad 10k", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
