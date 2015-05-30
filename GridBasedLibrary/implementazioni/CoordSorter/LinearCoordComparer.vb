''' <summary>
''' Rappresenta un comparatore lineare
''' </summary>
Public NotInheritable Class LinearCoordComparer
    Implements IComparer(Of ILocated)

    ''' <summary>
    ''' Rappresenta le opzioni disponibili per la comparazione
    ''' </summary>
    ''' <remarks>Da combinare con or</remarks>
    <Flags()>
    Public Enum LinearCoordComparerOption
        ''' <summary>
        ''' Utilizza le opzioni di default
        ''' </summary>
        [DEFAULT] = 0
        ''' <summary>
        ''' Indica di valutare prima la cordinata x(1)
        ''' </summary>
        FIRST_X = 1
        ''' <summary>
        ''' Indica di valutare di più le cordinate a sinistra rispetto a quelle a destra
        ''' </summary>
        RIGHT_TO_LEFT = 2
        ''' <summary>
        ''' Indica di valutare di più le cordinate più a basso rispetto a quelle alte
        ''' </summary>
        ''' <remarks></remarks>
        DOWN_TO_UP = 4
    End Enum
    ''' <summary>
    ''' Indica le opzioni da usare nella comparazione
    ''' </summary>
    Protected [option] As LinearCoordComparerOption

    ''' <summary>
    ''' Crea una nuova istanza di LinearCoordComparer
    ''' </summary>
    ''' <param name="option">Opzioni da usare</param>
    Public Sub New(Optional [option] As LinearCoordComparerOption = LinearCoordComparerOption.DEFAULT)
        'imposta le opzioni
        Me.option = [option]
    End Sub

    ''' <summary>
    ''' Restituisce le opzioni in uso
    ''' </summary>
    ''' <returns>Le opzioni</returns>
    Public Function GetOption() As LinearCoordComparerOption
        'restituisce option
        Return [option]
    End Function
    ''' <summary>
    ''' Imposta le opzioni
    ''' </summary>
    ''' <param name="op">opzioni da impostare</param>
    Public Sub SetOption(op As LinearCoordComparerOption)
        'imposta le opzioni
        [option] = op
    End Sub


    ''' <summary>
    ''' Compara 2 cordinate 
    ''' </summary>
    ''' <param name="c1">Cordinata X</param>
    ''' <param name="c2">Cordinata Y</param>
    ''' <returns>Maggiore di 1 se x viene prima di y, 0 se sono allo stesso livello, altrimenti minore di 1 se y viene prima di x</returns>
    Public Function Compare(c1 As ILocated, c2 As ILocated) As Integer Implements System.Collections.Generic.IComparer(Of ILocated).Compare
        'verifica se comparare prima la x poi la y
        If [option].HasFlag(LinearCoordComparerOption.FIRST_X) Then 'prima la x
            'verifica la x
            If c1.GetX < c2.GetX And Not [option].HasFlag(LinearCoordComparerOption.RIGHT_TO_LEFT) Then
                'restituisce -1
                Return -1
            ElseIf c1.GetX > c2.GetX And [option].HasFlag(LinearCoordComparerOption.RIGHT_TO_LEFT) Then
                'restituisce +1
                Return +1
            Else ' se c1 = c2 esegue il confronto di y
                If c1.GetY < c2.GetY And Not [option].HasFlag(LinearCoordComparerOption.DOWN_TO_UP) Then
                    'restituisce -1
                    Return -1
                ElseIf c1.GetY > c2.GetY And [option].HasFlag(LinearCoordComparerOption.DOWN_TO_UP) Then
                    'restituisce +1
                    Return +1
                Else
                    'restituisce 0
                    Return 0
                End If
            End If
        Else 'prima la y
            'verifica la y
            If c1.GetY < c2.GetY And Not [option].HasFlag(LinearCoordComparerOption.DOWN_TO_UP) Then
                'restituisce -1
                Return -1
            ElseIf c1.GetY > c2.GetY And [option].HasFlag(LinearCoordComparerOption.DOWN_TO_UP) Then
                'restituisce +1
                Return +1
            Else ' se c1 = c2 esegue il confronto di x
                If c1.GetX < c2.GetX And Not [option].HasFlag(LinearCoordComparerOption.RIGHT_TO_LEFT) Then
                    'restituisce -1
                    Return -1
                ElseIf c1.GetX > c2.GetX And [option].HasFlag(LinearCoordComparerOption.RIGHT_TO_LEFT) Then
                    'restituisce +1
                    Return +1
                Else
                    'restituisce 0
                    Return 0
                End If
            End If
        End If
    End Function
End Class
