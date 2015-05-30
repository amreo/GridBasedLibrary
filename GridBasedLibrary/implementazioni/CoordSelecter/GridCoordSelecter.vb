''' <summary>
''' Rappresenta un selecter di cordinate che utilizza un algoritmo a griglia
''' </summary>
Public Class GridCoordSelecter
    Inherits CoordSelecter

    ''' <summary>
    ''' Costante che indica che la cordinata non è selezionata
    ''' </summary>
    Protected Const NOT_SELECTED As Boolean = False
    ''' <summary>
    ''' Costante che indica che la cordinata è selezionata
    ''' </summary>
    Protected Const SELECTED As Boolean = True

    ''' <summary>
    ''' Rappresenta la mappa delle cordinate selezionate e non
    ''' </summary>
    Protected grid(,) As Boolean
    ''' <summary>
    ''' Regione dove è possibile selezionare le cordinate
    ''' </summary>
    Protected region As Rectangle
    ''' <summary>
    ''' Ottiene o imposta un valore che indica se ignorare i punti fuori dall' area
    ''' </summary>
    Protected ignoreOverPoint As Boolean

    ''' <summary>
    ''' Crea una nuova di GridCoordSelecter
    ''' </summary>
    ''' <param name="region">Regione</param>
    ''' <param name="ignoreOverPoint">Opzione che indica se ignorare il punti fuori dal rettangolo o lanciare un eccezione</param>
    Public Sub New(region As Rectangle, Optional ignoreOverPoint As Boolean = True)
        'imposta le variabili
        Me.region = region
        Me.ignoreOverPoint = ignoreOverPoint
        'ridimensiona grid
        ReDim grid(region.GetWidth, region.GetHeight)
    End Sub
    ''' <summary>
    ''' Crea una nuova di GridCoordSelecter
    ''' </summary>
    ''' <param name="offset">Locazione della regione</param>
    ''' <param name="size">Dimensione della regione</param>
    ''' <param name="ignoreOverPoint">Opzione che indica se ignorare il punti fuori dal rettangolo o lanciare un eccezione</param>
    Public Sub New(offset As Coord, size As Size, Optional ignoreOverPoint As Boolean = True)
        'imposta le variabili
        Me.region = New Rectangle(offset, size)
        Me.ignoreOverPoint = ignoreOverPoint
        'ridimensiona grid
        ReDim grid(region.GetWidth, region.GetHeight)
    End Sub
    ''' <summary>
    ''' Crea una nuova di GridCoordSelecter
    ''' </summary>
    ''' <param name="offset">Locazione della regione</param>
    ''' <param name="size">Dimensione della regione</param>
    ''' <param name="ignoreOverPoint">Opzione che indica se ignorare il punti fuori dal rettangolo o lanciare un eccezione</param>
    Public Sub New(offset As ILocated, size As Size, Optional ignoreOverPoint As Boolean = True)
        'imposta le variabili
        Me.region = New Rectangle(offset, size)
        Me.ignoreOverPoint = ignoreOverPoint
        'ridimensiona grid
        ReDim grid(region.GetWidth, region.GetHeight)
    End Sub
    ''' <summary>
    ''' Crea una nuova di GridCoordSelecter
    ''' </summary>
    ''' <param name="offX">Offset X</param>
    ''' <param name="offY">Offset Y</param>
    ''' <param name="width">Larghezza</param>
    ''' <param name="height">Altezza</param>
    ''' <param name="ignoreOverPoint">Opzione che indica se ignorare il punti fuori dal rettangolo o lanciare un eccezione</param>
    Public Sub New(offX As Integer, offY As Integer, width As UInteger, height As UInt32, Optional ignoreOverPoint As Boolean = True)
        'imposta le variabili
        Me.region = New Rectangle(offX, offY, width, height)
        Me.ignoreOverPoint = ignoreOverPoint
        'ridimensiona grid
        ReDim grid(region.GetWidth, region.GetHeight)
    End Sub

    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da selezionare</param>
    Public Overloads Overrides Sub [Select](c As ILocated)
        'seleziona il punto
        If Not region.Contains(c) Then
            'verifica che l'opzione ignoreOverPoint sia false per lanciare l'eccezione
            If Not ignoreOverPoint Then Throw New IndexOutOfRangeException("Il punto c" & c.ToString & " non può essere selezionato da " & Me.ToString & " perchè fuori dalla regione")
            Return
        End If
        'lo seleziona
        grid(c.GetX - region.GetX, c.GetY - region.GetY) = SELECTED
    End Sub
    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Sub [Select](x As Integer, y As Integer)
        'seleziona il punto
        If Not region.Contains(x, y) Then
            'verifica che l'opzione ignoreOverPoint sia false per lanciare l'eccezione
            If Not ignoreOverPoint Then Throw New IndexOutOfRangeException("Il punto c(" & x & "," & y & ") non può essere selezionato da " & Me.ToString & " perchè fuori dalla regione")
            Return
        End If
        'lo seleziona
        grid(x - region.GetX, y - region.GetY) = SELECTED
    End Sub

    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da deselezionare</param>
    Public Overloads Overrides Sub DeSelect(c As ILocated)
        'seleziona il punto. verifica che non sia fuori
        If Not region.Contains(c) Then Return
        'lo deseleziona
        grid(c.GetX - region.GetX, c.GetY - region.GetY) = NOT_SELECTED
    End Sub
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Sub DeSelect(x As Integer, y As Integer)
        'seleziona il punto. verifica che non sia fuori
        If Not region.Contains(x, y) Then Return
        'lo deseleziona
        grid(x - region.GetX, y - region.GetY) = NOT_SELECTED
    End Sub

    ''' <summary>
    ''' Deseleziona tutte le cordinate
    ''' </summary>
    Public Overrides Sub DeSelectAll()
        'cicla x e y
        For x = 0 To region.GetWidth - 1
            For y = 0 To region.GetHeight - 1
                'lo deseleziona
                grid(x, y) = NOT_SELECTED
            Next
        Next
    End Sub

    ''' <summary>
    ''' Ottiene le cordinate selezionate
    ''' </summary>
    ''' <returns>Cordinate selezionate</returns> 
    Public Overloads Overrides Function GetSelection() As Coord()
        'Restituisce i punti selezionati
        Dim l As New List(Of Coord)
        'cerca i punti
        For y = 0 To region.GetHeight - 1
            For x = 0 To region.GetWidth - 1
                'verifica che il punto è selezionato per aggiungerlo a l
                If grid(x, y) Then l.Add(New Coord(x + region.GetX, y + region.GetY))
            Next
        Next
        'restituisce l
        Return l.ToArray
    End Function

    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    Public Overloads Overrides Function IsSelected(c As ILocated) As Boolean
        'verifica che è selezionato
        If Not region.Contains(c) Then Return False
        Return grid(c.GetX - region.GetX, c.GetY - region.GetY)
    End Function
    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Function IsSelected(x As Integer, y As Integer) As Boolean
        'verifica che è selezionato
        If Not region.Contains(x, y) Then Return False
        Return grid(x - region.GetX, y - region.GetY)
    End Function

   
    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public Overrides Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Coord)
        'restituisce l'enumeratore
        Return New GridCoordSelectionEnumerator(Me)
    End Function
    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public Overrides Function GetEnumerator1() As System.Collections.IEnumerator
        'restituisce l'enumeratore
        Return New GridCoordSelectionEnumerator(Me)
    End Function

    ''' <summary>
    ''' Rappresenta l'enumeratore usato nei cicli for each
    ''' </summary>
    Protected Class GridCoordSelectionEnumerator
        Implements IEnumerator(Of Coord)

        ''' <summary>
        ''' Ottiene o imposta il gridSelecter da enumerare
        ''' </summary>
        Protected gridSelecter As GridCoordSelecter
        ''' <summary>
        ''' Ottiene la cordinata corrente interna(usata per accedere a grid)
        ''' </summary>
        Protected internalCurrent As Coord
        Protected startC As Boolean = True


        ''' <summary>
        ''' Crea una nuova istanza di GridCoordSelectionEnumerator
        ''' </summary>
        Public Sub New(gridSelecter As GridCoordSelecter)
            'imposta gridSelecter
            Me.gridSelecter = gridSelecter
        End Sub

        ''' <summary>
        ''' Ottiene la cordinata corrente
        ''' </summary>
        ''' <value>La cordinata corrente</value>
        ''' <returns>La cordinata corrente</returns>
        Public ReadOnly Property Current As Coord Implements System.Collections.Generic.IEnumerator(Of Coord).Current
            Get
                'restituisce la cordinata corrente
                Return New Coord(internalCurrent.GetX + gridSelecter.region.GetX, internalCurrent.GetY + gridSelecter.region.GetY)
            End Get
        End Property
        ''' <summary>
        ''' Ottiene la cordinata corrente
        ''' </summary>
        ''' <value>La cordinata corrente</value>
        ''' <returns>La cordinata corrente</returns>
        Public ReadOnly Property Current1 As Object Implements System.Collections.IEnumerator.Current
            Get
                'restituisce la cordinata corrente
                Return New Coord(internalCurrent.GetX + gridSelecter.region.GetX, internalCurrent.GetY + gridSelecter.region.GetY)
            End Get
        End Property

        ''' <summary>
        ''' Sposta in avanti la cordinata corrente
        ''' </summary>
        ''' <returns>True se è stato spostato con successo, altrimenti false</returns>
        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            'verifica che è la prima volta
            If startC Then
                'imposta startC su false
                startC = False
                'verifica che è selezionato 0 0
                If gridSelecter.grid(internalCurrent.GetX, internalCurrent.GetY) Then Return True
            End If
            'esegue la ricerca
            Do
                'sposta di 1 tempcurrent
                internalCurrent.MoveRight()
                'verifica che tempCurrent.X non sia uguale a region.getwidth
                If internalCurrent.GetX = gridSelecter.region.GetWidth Then
                    internalCurrent.SetX(0)
                    internalCurrent.MoveDown()
                    If internalCurrent.GetY = gridSelecter.region.GetHeight Then Return False
                End If
            Loop Until gridSelecter.grid(internalCurrent.GetX, internalCurrent.GetY)
            'se la ricerca è qui significa che è un successo
            Return True
        End Function
        ''' <summary>
        ''' Resetta la posizione di internalCurrent
        ''' </summary>
        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            'resetta la posizione a 0
            internalCurrent.Set(0, 0)
            startC = True
            'decide se mantenere la posizione o cercare il prossimo elemento
            If Not gridSelecter.grid(0, 0) Then MoveNext()
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: eliminare stato gestito (oggetti gestiti).
                End If

                ' TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del seguente Finalize().
                ' TODO: impostare campi di grandi dimensioni su null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: eseguire l'override di Finalize() solo se Dispose(ByVal disposing As Boolean) dispone del codice per liberare risorse non gestite.
        'Protected Overrides Sub Finalize()
        '    ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Class
