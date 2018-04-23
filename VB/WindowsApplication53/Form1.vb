Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Namespace WindowsApplication53
	Partial Public Class Form1
		Inherits Form
		Private pivotLayoutHelper As PivotLayoutHelper
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			PopulateTable()
			pivotGridControl1.RefreshData()
			pivotGridControl1.BestFit()
		End Sub
		Private Sub PopulateTable()
			Dim myTable As DataTable = dataSet1.Tables("Data")
			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today, 7 })
			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddDays(1), 4 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today, 12 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddDays(1), 14 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today, 11 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddDays(1), 10 })

			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddYears(1), 4 })
			myTable.Rows.Add(New Object() { "Aaa", DateTime.Today.AddYears(1).AddDays(1), 2 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddYears(1), 3 })
			myTable.Rows.Add(New Object() { "Bbb", DateTime.Today.AddDays(1).AddYears(1), 1 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddYears(1), 8 })
			myTable.Rows.Add(New Object() { "Ccc", DateTime.Today.AddDays(1).AddYears(1), 22 })
		End Sub
		Private stream As New MemoryStream()
		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			stream.Position = 0
			PivotLayoutHelper.SavePivot(pivotGridControl1, stream)
		End Sub
		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			stream.Position = 0
			PivotLayoutHelper.LoadPivot(pivotGridControl1, stream)
		End Sub

		Private Sub simpleButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton3.Click
			pivotGridControl1.Fields.Clear()
		End Sub
	End Class
End Namespace