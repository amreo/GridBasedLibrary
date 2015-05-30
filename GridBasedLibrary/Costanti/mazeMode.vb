''' <summary>
''' Enum che rappresenta la modalità di espansione del labirinto
''' </summary>
<Flags()>
Public Enum mazeMode

    ''' <summary>
    ''' Flag che indica di pulire la regione con muri
    ''' </summary>
    CLEAN = 1

    ''' <summary>
    ''' Flag che indica di espandersi verso su
    ''' </summary>
    UP = 2
    ''' <summary>
    ''' Flag che indica di espandersi verso dx-sopra
    ''' </summary>
    RIGHT_UP = 4
    ''' <summary>
    ''' Flag che indica di espandersi verso dx
    ''' </summary>
    RIGHT = 8
    ''' <summary>
    ''' Flag che indica di espandersi verso dx-giù
    ''' </summary>
    RIGHT_DOWN = 16
    ''' <summary>
    ''' Flag che indica di espandersi verso giù
    ''' </summary>
    DOWN = 32
    ''' <summary>
    ''' Flag che indica di espandersi verso sx-giù
    ''' </summary>
    LEFT_DOWN = 64
    ''' <summary>
    ''' Flag che indica di espandersi verso sx
    ''' </summary>
    LEFT = 128
    ''' <summary>
    ''' Flag che indica di espandersi verso sx-su
    ''' </summary>
    LEFT_UP = 256
    ''' <summary>
    ''' Flag che indica di espandersi verso le quattro direzioni
    ''' </summary>
    SQUARE = UP Or RIGHT Or LEFT Or DOWN
    ''' <summary>
    ''' Flag che indica di espandersi verso le direzioni diagonali
    ''' </summary>
    DIAGONAL = LEFT_UP Or LEFT_DOWN Or RIGHT_UP Or RIGHT_DOWN
    ''' <summary>
    ''' Flag che indica di espandersi in modo strict
    ''' </summary>
    STRICT = 512
End Enum