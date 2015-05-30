''' <summary>
''' Rappresenta una direzione
''' </summary>
''' <remarks>Supporta solo 9 direzioni(una NONE)</remarks>
Public Structure Direction
    Private value As Byte

    ''' <summary>
    ''' Rappresenta la direzione nulla
    ''' </summary>
    ''' <remarks>kx=0 ky=0 (x,y)</remarks>
    Public Shared ReadOnly NONE As New Direction(0)
    ''' <summary>
    ''' Rappresenta la direzione sopra
    ''' </summary>
    ''' <remarks>kx=0 ky=-1 (x,y-o)</remarks>
    Public Shared ReadOnly UP As New Direction(1)
    ''' <summary>
    ''' Rappresenta la direzione sopra a dx
    ''' </summary>
    ''' <remarks>kx=1 ky=-1 (x+o,y-o)</remarks>
    Public Shared ReadOnly RIGHT_UP As New Direction(2)
    ''' <summary>
    ''' Rappresenta la direzione dx
    ''' </summary>
    ''' <remarks>kx=1 ky=0 (x+o,y)</remarks>
    Public Shared ReadOnly RIGHT As New Direction(3)
    ''' <summary>
    ''' Rappresenta la direzione sotto a dx
    ''' </summary>
    ''' <remarks>kx=1 ky=1 (x+o,y+o)</remarks>
    Public Shared ReadOnly RIGHT_DOWN As New Direction(4)
    ''' <summary>
    ''' Rappresenta la direzione sotto
    ''' </summary>
    ''' <remarks>kx=0 ky=+1 (x,y+o)</remarks>
    Public Shared ReadOnly DOWN As New Direction(5)
    ''' <summary>
    ''' Rappresenta la direzione sotto a sx
    ''' </summary>
    ''' <remarks>kx=-1 ky=1 (x-o,y+o)</remarks>
    Public Shared ReadOnly LEFT_DOWN As New Direction(6)
    ''' <summary>
    ''' Rappresenta la direzione sx
    ''' </summary>
    ''' <remarks>kx=-1 ky=0 (x-o,y)</remarks>
    Public Shared ReadOnly LEFT As New Direction(7)
    ''' <summary>
    ''' Rappresenta la direzione sopra a sx
    ''' </summary>
    ''' <remarks>kx=-1 ky=-1 (x-o,y-o)</remarks>
    Public Shared ReadOnly LEFT_UP As New Direction(8)

    ''' <summary>
    ''' Crea una nuova istanza di Direction
    ''' </summary>
    ''' <param name="value">Valore di direzione</param>
    Public Sub New(ByVal value As Byte)
        'verifica che sia corretto
        If value > 8 Then Throw New OverflowException("Valore 'value' maggiore di 8")
        'imposta value
        Me.value = value
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di Direction
    ''' </summary>
    ''' <param name="source">Direzione originaria</param>
    Public Sub New(ByVal source As Direction)
        'imposta la direzione
        Me.value = source.value
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di Direction
    ''' </summary>
    ''' <param name="coeX">Coefficiente X</param>
    ''' <param name="coeY">Coefficiente Y</param>
    Public Sub New(ByVal coeX As coefficientDirection, coeY As coefficientDirection)
        'imposta la direzione in base a coeX
        Select Case coeX
            Case coefficientDirection.NONE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = NONE.value
                    Case coefficientDirection.MOVE
                        Me.value = DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = UP.value
                End Select
            Case coefficientDirection.MOVE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = RIGHT.value
                    Case coefficientDirection.MOVE
                        Me.value = RIGHT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = RIGHT_UP.value
                End Select
            Case coefficientDirection.MOVE_OPPOSTE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = LEFT.value
                    Case coefficientDirection.MOVE
                        Me.value = LEFT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = LEFT_UP.value
                End Select
        End Select
    End Sub

    ''' <summary>
    ''' Restituisce la direzione opposta a questa direzione
    ''' </summary>
    ''' <returns>Direzione opposta</returns>
    Public Function Opposite() As Direction
        'base a value viene restituita la direzione opposta
        Select Case Me
            Case NONE
                Return NONE
            Case UP
                Return DOWN
            Case DOWN
                Return UP
            Case LEFT
                Return RIGHT
            Case RIGHT
                Return LEFT
            Case LEFT_UP
                Return RIGHT_DOWN
            Case RIGHT_DOWN
                Return LEFT_UP
            Case LEFT_DOWN
                Return RIGHT_UP
            Case RIGHT_UP
                Return LEFT_DOWN
            Case Else
                Return NONE
        End Select
    End Function

    ''' <summary>
    ''' Ottiene il coefficente X
    ''' </summary>
    ''' <returns>Coefficente X</returns>
    Public Function GetCoefficientX() As coefficientDirection
        'ottiene il coefficiente x verificando i casi
        Select Case Me
            Case LEFT_UP, LEFT, LEFT_DOWN
                Return coefficientDirection.MOVE_OPPOSTE
            Case UP, NONE, DOWN
                Return coefficientDirection.NONE
            Case RIGHT_UP, RIGHT, RIGHT_DOWN
                Return coefficientDirection.MOVE
            Case Else
                Return coefficientDirection.NONE
        End Select
    End Function
    ''' <summary>
    ''' Ottiene il coefficente Y
    ''' </summary>
    ''' <returns>Coefficente Y</returns>
    Public Function GetCoefficientY() As coefficientDirection
        'ottiene il coefficiente y verificando i casi
        Select Case Me
            Case LEFT_UP, UP, RIGHT_UP
                Return coefficientDirection.MOVE_OPPOSTE
            Case LEFT, NONE, RIGHT
                Return coefficientDirection.NONE
            Case LEFT_DOWN, DOWN, RIGHT_DOWN
                Return coefficientDirection.MOVE
            Case Else
                Return coefficientDirection.NONE
        End Select
    End Function

    ''' <summary>
    ''' Imposta la direzione in vase a value
    ''' </summary>
    ''' <param name="value">Valore della direzione</param>
    Public Sub SetDirection(value As Byte)
        'verifica che sia corretto
        If value > 8 Then Throw New OverflowException("Valore 'value' maggiore di 8")
        'imposta value
        Me.value = value
    End Sub
    ''' <summary>
    ''' Imposta la direzione in vase a source
    ''' </summary>
    ''' <param name="source">Direzione originaria</param>
    Public Sub SetDirection(source As Direction)
        'imposta value
        Me.value = source.value
    End Sub
    ''' <summary>
    ''' Imposta la direzione in base ai coefficienti
    ''' </summary>
    ''' <param name="coeX">Coefficiente X</param>
    ''' <param name="coeY">Coefficiente Y</param>
    Public Sub SetDirection(ByVal coeX As coefficientDirection, coeY As coefficientDirection)
        'imposta la direzione in base a coeX
        Select Case coeX
            Case coefficientDirection.NONE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = NONE.value
                    Case coefficientDirection.MOVE
                        Me.value = DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = UP.value
                End Select
            Case coefficientDirection.MOVE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = RIGHT.value
                    Case coefficientDirection.MOVE
                        Me.value = RIGHT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = RIGHT_UP.value
                End Select
            Case coefficientDirection.MOVE_OPPOSTE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = LEFT.value
                    Case coefficientDirection.MOVE
                        Me.value = LEFT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = LEFT_UP.value
                End Select
        End Select
    End Sub
    ''' <summary>
    ''' Imposta la direzione in base a coeX
    ''' </summary>
    ''' <param name="coeX">Coefficiente X</param>
    Public Sub SetDirectionByCoefficientX(ByVal coeX As coefficientDirection)
        'imposta la direzione in base a coeX
        Select Case coeX
            Case coefficientDirection.NONE
                'base a coeY
                Select Case GetCoefficientY()
                    Case coefficientDirection.NONE
                        Me.value = NONE.value
                    Case coefficientDirection.MOVE
                        Me.value = DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = UP.value
                End Select
            Case coefficientDirection.MOVE
                'base a coeY
                Select Case GetCoefficientY()
                    Case coefficientDirection.NONE
                        Me.value = RIGHT.value
                    Case coefficientDirection.MOVE
                        Me.value = RIGHT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = RIGHT_UP.value
                End Select
            Case coefficientDirection.MOVE_OPPOSTE
                'base a coeY
                Select Case GetCoefficientY()
                    Case coefficientDirection.NONE
                        Me.value = LEFT.value
                    Case coefficientDirection.MOVE
                        Me.value = LEFT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = LEFT_UP.value
                End Select
        End Select
    End Sub
    ''' <summary>
    ''' Imposta la direzione in base a coeY
    ''' </summary>
    ''' <param name="coeY">Coefficiente Y</param>
    Public Sub SetDirectionByCoefficientY(ByVal coeY As coefficientDirection)
        'imposta la direzione in base a coeX
        Select Case GetCoefficientX()
            Case coefficientDirection.NONE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = NONE.value
                    Case coefficientDirection.MOVE
                        Me.value = DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = UP.value
                End Select
            Case coefficientDirection.MOVE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = RIGHT.value
                    Case coefficientDirection.MOVE
                        Me.value = RIGHT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = RIGHT_UP.value
                End Select
            Case coefficientDirection.MOVE_OPPOSTE
                'base a coeY
                Select Case coeY
                    Case coefficientDirection.NONE
                        Me.value = LEFT.value
                    Case coefficientDirection.MOVE
                        Me.value = LEFT_DOWN.value
                    Case coefficientDirection.MOVE_OPPOSTE
                        Me.value = LEFT_UP.value
                End Select
        End Select
    End Sub

    ''' <summary>
    ''' Combina le direzioni
    ''' </summary>
    ''' <param name="dirA">Direzione A</param>
    ''' <param name="dirB">Direzione B</param>
    ''' <returns>Direzione combinata</returns>
    Public Shared Function CombineDirection(dirA As Direction, dirB As Direction) As Direction
        'crea la nuova direzione e la restituisce
        Return New Direction(CombineCoefficient(dirA.GetCoefficientX, dirB.GetCoefficientX), CombineCoefficient(dirA.GetCoefficientY, dirB.GetCoefficientY))
    End Function
    ''' <summary>
    ''' Combina i 2 coefficienti
    ''' </summary>
    ''' <param name="coeA">Coefficiente A</param>
    ''' <param name="coeB">Coefficiente B</param>
    ''' <returns>Coefficiente combinato</returns>
    Public Shared Function CombineCoefficient(coeA As coefficientDirection, coeB As coefficientDirection) As coefficientDirection
        'verifica i casi dei coefficienti
        If coeA = coefficientDirection.NONE Then Return coeB
        If coeB = coefficientDirection.NONE Then Return coeA
        If coeA = coeB Then Return coeA
        Return coefficientDirection.NONE
    End Function

    Public Shared Operator <>(ByVal left As Direction, ByVal right As Direction) As Boolean
        'verifica che sono diversi
        Return left.value <> right.value
    End Operator
    Public Shared Operator =(ByVal left As Direction, ByVal right As Direction) As Boolean
        'verifica che sono diversi
        Return left.value = right.value
    End Operator

    ''' <summary>
    ''' Ottiene la rotazione di n direzioni di 1
    ''' </summary>
    ''' <param name="n">Numero di rotazione</param>
    ''' <returns>Direzione ruotata</returns>
    ''' <remarks>è possibile specificare un n negativo, in questo caso sarà rotato antiorario</remarks>
    Public Function GetRotate(n As Integer) As Direction
        'verifica se n è positivo, negativo o uguale a 0
        Const FULL As Integer = 8 'rappresenta il numero totale di direzioni, sommare 8 equivale a fare il giro completo
        'toglie più giri completi possibili a n
        n = n Mod FULL
        'ottiene il complemento di n se n è negativo
        If n < 0 Then n = n + FULL
        'restituisce la direzione
        Return New Direction((Me.value + n) Mod FULL)
        'matematica delle rotazoni XD
    End Function
End Structure
