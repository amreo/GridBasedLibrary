''' <summary>
''' Rappresenta un selecter che utilizza un algoritmo con la lista
''' </summary>
Public Class ListCoordSelecter
    Inherits CoordSelecter

    ''' <summary>
    ''' Ottiene o imposta la lista di elementi selezionati
    ''' </summary>
    Protected coordList As List(Of Coord)

    ''' <summary>
    ''' Crea una nuova istanza di ListCoordSelecter
    ''' </summary>
    Public Sub New()
        'istanzia coordList
        coordList = New List(Of Coord)
    End Sub

    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Sub [Select](ByVal x As Integer, ByVal y As Integer)
        'verifica che non esiste già
        If Not coordList.Contains(New Coord(x, y)) Then coordList.Add(New Coord(x, y))
    End Sub
    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da selezionare</param>
    Public Overloads Overrides Sub [Select](ByVal c As ILocated)
        'verifica che non esiste già
        If Not coordList.Contains(c.GetLocation) Then coordList.Add(c)
    End Sub

    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Sub DeSelect(ByVal x As Integer, ByVal y As Integer)
        'deseleziona il punto solo se è nella lista
        Dim index As Integer = coordList.IndexOf(New Coord(x, y))
        If index <> -1 Then coordList.RemoveAt(index)
    End Sub
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da deselezionare</param>
    Public Overloads Overrides Sub DeSelect(ByVal c As ILocated)
        'deseleziona il punto solo se è nella lista
        Dim index As Integer = coordList.IndexOf(New Coord(c))
        If index <> -1 Then coordList.RemoveAt(index)
    End Sub
    ''' <summary>
    ''' Deseleziona tutte le cordinate
    ''' </summary>
    Public Overloads Overrides Sub DeSelectAll()
        'svuota l'intera lista
        coordList.Clear()
    End Sub


    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public Overloads Overrides Function IsSelected(ByVal x As Integer, ByVal y As Integer) As Boolean
        'verifica che è selezionato
        Return coordList.Contains(New Coord(x, y))
    End Function
    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    Public Overloads Overrides Function IsSelected(ByVal c As ILocated) As Boolean
        'verifica che è selezionato
        Return coordList.Contains(New Coord(c))
    End Function

    ''' <summary>
    ''' Ottiene le cordinate selezionate
    ''' </summary>
    ''' <returns>Cordinate selezionate</returns> 
    Public Overloads Overrides Function GetSelection() As Coord()
        'restituisce la lista convertita in array
        Return coordList.ToArray()
    End Function


    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public Overloads Overrides Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Coord)
        'restituisce l'enumeratore
        Return New ListCoordSelectionEnumerator(Me)
    End Function
    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public Overloads Overrides Function GetEnumerator1() As System.Collections.IEnumerator
        'restituisce l'enumeratore
        Return New ListCoordSelectionEnumerator(Me)
    End Function

    ''' <summary>
    ''' Rappresenta un enumeratore usato da ListCoordSelecter
    ''' </summary>
    Protected Class ListCoordSelectionEnumerator
        Implements IEnumerator(Of Coord)

        ''' <summary>
        ''' Ottiene o imposta il selecter
        ''' </summary>
        Protected ListSelecter As ListCoordSelecter
        ''' <summary>
        ''' Ottiene o imposta l'indice corrente
        ''' </summary>
        Protected index As Integer

        ''' <summary>
        ''' Crea una nuova istanza di ListCoordSelectionEnumerator
        ''' </summary>
        ''' <param name="Sel">Selecter</param>
        Public Sub New(Sel As ListCoordSelecter)
            'imposta sel
            ListSelecter = Sel
            'inizializza index
            index = ListSelecter.coordList.Count
        End Sub

        ''' <summary>
        ''' Ottiene l'elemento corrente
        ''' </summary>
        ''' <value>Elemento corrente</value>
        ''' <returns>Elemento corrente</returns>           
        Public ReadOnly Property Current As Coord Implements System.Collections.Generic.IEnumerator(Of Coord).Current
            Get
                'restituisce l'elemento corrente
                Return ListSelecter.coordList(index)
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
                Return ListSelecter.coordList(index)
            End Get
        End Property
        ''' <summary>
        ''' Sposta in avanti la cordinata corrente
        ''' </summary>
        ''' <returns>True se è stato spostato con successo, altrimenti false</returns>
        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            'diminuisce di 1 index
            index -= 1
            'restituisce true se index è maggiore 0
            Return index > -1
        End Function
        ''' <summary>
        ''' Resetta la posizione di current
        ''' </summary>
        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            'inizializza index
            index = ListSelecter.coordList.Count
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
