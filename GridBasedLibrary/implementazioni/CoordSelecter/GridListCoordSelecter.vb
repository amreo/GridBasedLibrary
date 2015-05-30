''' <summary>
''' Rappresenta un selecter che utilizza un algoritmo a lista con griglia
''' </summary>
Public Class GridListCoordSelecter
    Inherits CoordSelecter

    ''' <summary>
    ''' Rappresenta la mappa delle cordinate selezionate e non
    ''' </summary>
    Protected grid(,) As LinkedListNode(Of Coord)
    ''' <summary>
    ''' Rappresenta l'elenco di cordinate selezionate
    ''' </summary>
    Protected list As LinkedList(Of Coord)
    ''' <summary>
    ''' Regione dove è possibile selezionare le cordinate
    ''' </summary>
    Protected region As Rectangle
    ''' <summary>
    ''' Ottiene o imposta un valore che indica se ignorare i punti fuori dall' area
    ''' </summary>
    Protected ignoreOverPoint As Boolean

    ''' <summary>
    ''' Crea una nuova di GridListCoordSelecter
    ''' </summary>
    ''' <param name="region">Regione</param>
    ''' <param name="ignoreOverPoint">Opzione che indica se ignorare il punti fuori dal rettangolo o lanciare un eccezione</param>
    Public Sub New(region As Rectangle, Optional ignoreOverPoint As Boolean = True)
        'imposta le variabili
        Me.region = region
        Me.ignoreOverPoint = ignoreOverPoint
        'ridimensiona grid
        ReDim grid(region.GetWidth, region.GetHeight)
        list = New LinkedList(Of Coord)
    End Sub
    ''' <summary>
    ''' Crea una nuova di GridListCoordSelecter
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
        list = New LinkedList(Of Coord)
    End Sub
    ''' <summary>
    ''' Crea una nuova di GridListCoordSelecter
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
        list = New LinkedList(Of Coord)
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
        list = New LinkedList(Of Coord)
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
        grid(c.GetX - region.GetX, c.GetY - region.GetY) = list.AddLast(New Coord(c.GetX - region.GetX, c.GetY - region.GetY))
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
        grid(x - region.GetX, y - region.GetY) = list.AddLast(New Coord(x - region.GetX, y - region.GetY))
    End Sub

    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da deselezionare</param>
    Public Overloads Overrides Sub DeSelect(c As ILocated)
        'seleziona il punto. verifica che non sia fuori
        If Not IsSelected(c) Then Return
        'lo deseleziona
        list.Remove(grid(c.GetX - region.GetX, c.GetY - region.GetY))
        grid(c.GetX - region.GetX, c.GetY - region.GetY) = Nothing
    End Sub
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Sub DeSelect(x As Integer, y As Integer)
            'seleziona il punto. verifica che non sia fuori
            If Not IsSelected(x, y) Then Return
            'lo deseleziona
            list.Remove(grid(x - region.GetX, y - region.GetY))
            grid(x - region.GetX, y - region.GetY) = Nothing
    End Sub

    ''' <summary>
    ''' Deseleziona tutte le cordinate
    ''' </summary>
    Public Overrides Sub DeSelectAll()
        'cicla ogni cordinata selezionata
        For i = list.Count - 1 To 0 Step -1
            'rimuove il riferimento alla griglia
            grid(list(i).GetX - region.GetX, list(i).GetY - region.GetY) = Nothing
            list.Remove(list(i))
        Next
    End Sub

    ''' <summary>
    ''' Ottiene le cordinate selezionate
    ''' </summary>
    ''' <returns>Cordinate selezionate</returns> 
    Public Overloads Overrides Function GetSelection() As Coord()
        'restituisce l
        Return list.ToArray
    End Function

    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    Public Overloads Overrides Function IsSelected(c As ILocated) As Boolean
        'verifica che è selezionato
        If Not region.Contains(c) Then Return False
        Return Not grid(c.GetX - region.GetX, c.GetY - region.GetY) Is Nothing
    End Function
    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Function IsSelected(x As Integer, y As Integer) As Boolean
        'verifica che è selezionato
        If Not region.Contains(x, y) Then Return False
        Return Not grid(x - region.GetX, y - region.GetY) Is Nothing
    End Function


    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public Overrides Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Coord)
        'restituisce l'enumeratore
        Return New GridListCoordSelectionEnumerator(Me)
    End Function
    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public Overrides Function GetEnumerator1() As System.Collections.IEnumerator
        'restituisce l'enumeratore
        Return New GridListCoordSelectionEnumerator(Me)
    End Function

    ''' <summary>
    ''' Rappresenta un enumeratore usato da ListCoordSelecter
    ''' </summary>
    Protected Class GridListCoordSelectionEnumerator
        Implements IEnumerator(Of Coord)

        ''' <summary>
        ''' Ottiene o imposta il selecter
        ''' </summary>
        Protected ListSelecter As GridListCoordSelecter
        ''' <summary>
        ''' Ottiene o imposta l'indice corrente
        ''' </summary>
        Protected index As LinkedListNode(Of Coord)
        ''' <summary>
        ''' Indica se l'indice è iniziale(0)
        ''' </summary>
        Protected initialIndex As Boolean = True

        ''' <summary>
        ''' Crea una nuova istanza di GridListCoordSelectionEnumerator
        ''' </summary>
        ''' <param name="Sel">Selecter</param>
        Public Sub New(Sel As GridListCoordSelecter)
            'imposta sel
            ListSelecter = Sel
            'inizializza index
            index = ListSelecter.list.Last
        End Sub

        ''' <summary>
        ''' Ottiene l'elemento corrente
        ''' </summary>
        ''' <value>Elemento corrente</value>
        ''' <returns>Elemento corrente</returns>           
        Public ReadOnly Property Current As Coord Implements System.Collections.Generic.IEnumerator(Of Coord).Current
            Get
                'restituisce l'elemento corrente
                Return index.Value
            End Get
        End Property
        ''' <summary>
        ''' Ottiene l'elemento corrente
        ''' </summary>
        ''' <value>Elemento corrente</value>
        ''' <returns>Elemento corrente</returns>    
        Public ReadOnly Property Current1 As Object Implements System.Collections.IEnumerator.Current
            Get
                'restituisce l'elemento corrente
                Return index.Value
            End Get
        End Property
        ''' <summary>
        ''' Sposta in avanti la cordinata corrente
        ''' </summary>
        ''' <returns>True se è stato spostato con successo, altrimenti false</returns>
        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            'verifica che non è l'indice iniziale
            If initialIndex Then
                'disabilità la flag
                initialIndex = False
                'restituisce true se non è nothing
                Return Not index Is Nothing
            End If
            'diminuisce di 1 index
            index = index.Previous
            'restituisce true se index è maggiore 0
            Return Not index Is Nothing
        End Function
        ''' <summary>
        ''' Resetta la posizione di current
        ''' </summary>
        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            'inizializza index
            index = ListSelecter.list.Last
            initialIndex = True
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
