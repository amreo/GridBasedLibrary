''' <summary>
''' Interfaccia che rappresenta una funzione per il calcolo della distanza tra 2 punti
''' </summary>
''' <remarks>Può essere usato per scopi euristici</remarks>
Public Interface ICoordDistanceFunction

    ''' <summary>
    ''' Calcola la distanza tra 1 e 2
    ''' </summary>
    ''' <param name="x1">Cordinata x del punto 1</param>
    ''' <param name="y1">Cordinata y del punto 1</param>
    ''' <param name="x2">Cordinata x del punto 2</param>
    ''' <param name="y2">Cordinata y del punto 2</param>
    ''' <param name="scale">Valore di scala</param>
    ''' <returns>Un valore che indica la distanza (euristica) tra punto 1 e 2</returns>
    Function GetDistance(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, Optional scale As Single = 1.0) As Single
    ''' <summary>
    ''' Calcola la distanza tra 1 e 2
    ''' </summary>
    ''' <param name="c1">Cordinata 1</param>
    ''' <param name="c2">Cordinata 2</param>
    ''' <param name="scale">Valore di scala</param>
    ''' <returns>Un valore che indica la distanza (euristica) tra punto 1 e 2</returns>
    Function GetDistance(c1 As ILocated, c2 As ILocated, Optional scale As Single = 1.0) As Single
End Interface
