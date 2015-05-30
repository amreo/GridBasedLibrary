''' <summary>
''' Rappresenta l'interfaccia di qualunque oggetto in grado di lanciare un errore
''' </summary>
Public Interface IErrorable

    ''' <summary>
    ''' Evento che si verifica quando viene lanciato un errore
    ''' </summary>
    ''' <param name="sender">Oggetto che ha lanciato errore</param>
    ''' <param name="ex">Eccezione rilevata</param>
    Event [Error](ByVal sender As Object, ex As Exception)

    ''' <summary>
    ''' Lancia volutamente l'eccezione
    ''' </summary>
    ''' <param name="ex">Eccezione da lanciare</param>
    Sub OnError(ex As Exception)
End Interface
