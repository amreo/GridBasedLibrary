''' <summary>
''' Enum chè rappresenta le flag per lo startPoint
''' </summary>
<Flags()>
Public Enum flagStartPoint
    ''' <summary>
    ''' Viene considerato come startPoint customizzato
    ''' </summary>
    NONE = 0
    ''' <summary>
    ''' Lo SP può essere a sinistra
    ''' </summary>
    LEFT = 1
    ''' <summary>
    ''' Lo SP può essere sopra
    ''' </summary>
    UP = 2
    ''' <summary>
    ''' Lo SP può essere a destra
    ''' </summary>
    RIGHT = 4
    ''' <summary>
    ''' Lo SP può essere sotto
    ''' </summary>
    DOWN = 8
    ''' <summary>
    ''' Lo SP può essere al centro
    ''' </summary>
    CENTRAL = 16
    ''' <summary>
    ''' Lo SP non può essere agli angoli
    ''' </summary>
    IGNORE_ANGLE = 32
    ''' <summary>
    ''' Gli angoli per essere considerati devono avere la flag dei lati adiacenti abilitati
    ''' </summary>
    ''' <remarks></remarks>
    DOUBLE_SIDE_ANGLE = 64
End Enum