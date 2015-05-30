''' <summary>
''' Rappresenta un generatore di mappe casuali
''' </summary>
Public MustInherit Class RandomMapGenerator
    Inherits MapGenerator

    ''' <summary>
    ''' Ottiene o imposta il generatore 
    ''' </summary>
    Protected RandomGenerator As IRandomGenerator

    ''' <summary>
    ''' Crea una nuova istanza di RandomMapGenerator
    ''' </summary>
    ''' <param name="rnd">Generatore di numeri casuali</param>
    Protected Sub New(rnd As IRandomGenerator)
        'imposta il RandomGenerator
        RandomGenerator = rnd
    End Sub

End Class
