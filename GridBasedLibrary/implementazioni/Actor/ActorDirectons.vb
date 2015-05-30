''' <summary>
''' Elenco di direzioni che un attore è in grado di fare
''' </summary>
<Flags()>
Public Enum ActorDirections
    ''' <summary>
    ''' Flag che indica di espandersi verso su
    ''' </summary>
    UP = 1
    ''' <summary>
    ''' Flag che indica di espandersi verso dx-sopra
    ''' </summary>
    RIGHT_UP = 2
    ''' <summary>
    ''' Flag che indica di espandersi verso dx
    ''' </summary>
    RIGHT = 4
    ''' <summary>
    ''' Flag che indica di espandersi verso dx-giù
    ''' </summary>
    RIGHT_DOWN = 8
    ''' <summary>
    ''' Flag che indica di espandersi verso giù
    ''' </summary>
    DOWN = 16
    ''' <summary>
    ''' Flag che indica di espandersi verso sx-giù
    ''' </summary>
    LEFT_DOWN = 32
    ''' <summary>
    ''' Flag che indica di espandersi verso sx
    ''' </summary>
    LEFT = 64
    ''' <summary>
    ''' Flag che indica di espandersi verso sx-su
    ''' </summary>
    LEFT_UP = 128
    ''' <summary>
    ''' Flag che indica di espandersi verso le quattro direzioni
    ''' </summary>
    SQUARE = UP Or RIGHT Or LEFT Or DOWN
    ''' <summary>
    ''' Flag che indica di espandersi verso le direzioni diagonali
    ''' </summary>
    DIAGONAL = LEFT_UP Or LEFT_DOWN Or RIGHT_UP Or RIGHT_DOWN
End Enum
