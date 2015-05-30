''' <summary>
''' Rappresenta la classe base dei oggetti in grado di causare errori
''' </summary>
Public Class Errorable
    Implements IErrorable

    ''' <summary>
    ''' Evento che si verifica quando viene lanciato un errore
    ''' </summary>
    ''' <param name="sender">Oggetto che ha lanciato errore</param>
    ''' <param name="ex">Eccezione rilevata</param>
    Public Event [Error](sender As Object, ex As Exception) Implements IErrorable.Error

    ''' <summary>
    ''' Lancia volutamente l'eccezione
    ''' </summary>
    ''' <param name="ex">Eccezione da lanciare</param>
    Public Sub OnError(ex As Exception) Implements IErrorable.OnError
        'lancia l'evento che gestisce l'errore
        RaiseEvent Error(Me, ex)
    End Sub

    ''' <summary>
    ''' EventHandler di default che scrive su 2 l'eccezione
    ''' </summary>
    ''' <param name="sender">Oggetto che lanciato l'eccezione</param>
    ''' <param name="ex">Eccezione lanciata</param>
    Protected Sub Errorable_Error(sender As Object, ex As Exception) Handles Me.Error
        'scrive su 2 l'eccezione
        Console.Error.WriteLine(ex.ToString)
    End Sub
End Class