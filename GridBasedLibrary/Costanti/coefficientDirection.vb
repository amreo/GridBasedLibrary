''' <summary>
''' Elenco di coefficienti per l'offset nel calcolo delle direzioni
''' </summary>
Public Enum coefficientDirection
    ''' <summary>
    ''' Coefficiente nullo
    ''' </summary>
    ''' <remarks>Significa che la x o la y non cambia</remarks>
    NONE = 0
    ''' <summary>
    ''' Coefficiente spostamento
    ''' </summary>
    ''' <remarks>Significa che la x o la y si sposta di offset</remarks>
    MOVE = 1
    ''' <summary>
    ''' Coefficiente spostamento
    ''' </summary>
    ''' <remarks>Significa che la X si sposta di -offset</remarks>
    MOVE_OPPOSTE = -1
End Enum
