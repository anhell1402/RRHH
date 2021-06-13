Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection
Public Class ConexDB
    Implements IDisposable

    Private oCon As SqlConnection
    Private oCmd As SqlCommand
    Private dr As SqlDataReader
    Private hayError_ As Boolean
    Private mensajeError_ As String
    ''' <summary>
    ''' True si existe algún error al ejecutar el comando SQL
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property HayError As Boolean
        Get
            Return hayError_
        End Get
    End Property

    Public ReadOnly Property MensajeError As String
        Get
            Return mensajeError_
        End Get
    End Property

    Private Sub AbreConexion()
        Try
            oCon.Open()
            hayError_ = False
        Catch ex As Exception
            hayError_ = True
            mensajeError_ = ex.Message
        End Try
    End Sub
    ''' <summary>
    ''' Constructor que CREA y ABRE la conexión a la BD
    ''' </summary>
    ''' <param name="cadena">La cadena de conexión a la BD</param>
    Public Sub New(ByVal cadena As String)
        hayError_ = False
        mensajeError_ = String.Empty
        oCon = New SqlConnection(cadena)
        AbreConexion()
    End Sub
    Public Sub CerrarConexion()
        'If (oCon.State = ConnectionState.Open) Then
        '    oCon.Close()
        'End If
        'oCon.Dispose()
        Me.Dispose()
    End Sub

    Public WriteOnly Property EstablecerTipoComando As TipoComando
        Set(value As TipoComando)
            Select Case value
                Case TipoComando.ComandoEnTexto
                    oCmd.CommandType = CommandType.Text
                Case TipoComando.ProcedimientoAlmacenado
                    oCmd.CommandType = CommandType.StoredProcedure
            End Select
        End Set
    End Property
    ''' <summary>
    ''' Función que crea e inicia el comando SQL a ejecutar. En caso de error, cierra la conexión
    ''' </summary>
    ''' <param name="nombreComando">El nombre del comando</param>
    Public Sub CrearComando(ByVal nombreComando As String)
        oCmd = New SqlCommand(nombreComando, oCon)
    End Sub
    Public Sub EjecutaComando()
        If Not hayError_ Then
            Try
                oCmd.ExecuteNonQuery()
            Catch ex As Exception
                hayError_ = True
                mensajeError_ = ex.Message
                CerrarConexion()
            End Try
        End If
    End Sub
    ''' <summary>
    ''' Función que agrega el valor y parámetro a un comando SQL
    ''' </summary>
    ''' <param name="nombreParametro">El nombre del parámetro</param>
    ''' <param name="valorParametro">El valor que tomará el parámetro</param>
    Public Sub AgregarParametro(ByVal nombreParametro As String, ByVal valorParametro As Object)
        oCmd.Parameters.AddWithValue(nombreParametro, valorParametro)
    End Sub
    ''' <summary>
    ''' Función que agrega el valor y parámetro a un comando SQL
    ''' </summary>
    ''' <param name="nombreParametro">El nombre del parámetro</param>
    ''' <param name="valorParametro">El valor que tomará el parámetro</param>
    ''' <param name="direccion">La dirección del parámetro</param>
    Public Sub AgregarParametro(ByVal nombreParametro As String, ByVal valorParametro As Object,
                                ByVal direccion As TipoParametro)
        Select Case direccion
            Case TipoParametro.Entrada
                oCmd.Parameters.AddWithValue(nombreParametro, valorParametro).Direction = ParameterDirection.Input
            Case TipoParametro.Salida
                oCmd.Parameters.AddWithValue(nombreParametro, valorParametro).Direction = ParameterDirection.Output
            Case TipoParametro.EntradaSalida
                oCmd.Parameters.AddWithValue(nombreParametro, valorParametro).Direction = ParameterDirection.InputOutput
        End Select
    End Sub

    Private Function ConvertirADataTable(ByVal dr As SqlDataReader) As DataTable
        Dim dt As New DataTable()
        dt.Load(dr)
        Return dt
    End Function
    ''' <summary>
    ''' Función que regresa los resultados en un DataTable genérico
    ''' </summary>
    ''' <returns>El dataTable con los datos</returns>
    Public Function ObtenerResultados() As DataTable
        dr = oCmd.ExecuteReader()
        Return ConvertirADataTable(dr)
    End Function
    ''' <summary>
    ''' Función que ejecuta el comando SQL y obtiene el valor del parámetro de salida
    ''' </summary>
    ''' <param name="nombreParametro">Nombre del parámetro</param>
    ''' <returns>El valor del parámetro</returns>
    Public Function EjecutaComando(ByVal nombreParametro As String) As String
        Dim valor As String = String.Empty
        Try
            'EjecutaComando()
            'If (Not hayError_) Then
            oCmd.ExecuteNonQuery()
            valor = oCmd.Parameters(nombreParametro).Value.ToString()
            'End If
            'hayError_ = False
        Catch ex As Exception
            hayError_ = True
            mensajeError_ = ex.Message
            CerrarConexion()
        End Try
        Return valor
    End Function

    Private Function GetItem(Of T)(ByVal dr As DataRow) As T
        Dim temp As Type = GetType(T)
        Dim obj As T = Activator.CreateInstance(Of T)()
        Dim propiedad As String = String.Empty
        Try
            For Each colum As DataColumn In dr.Table.Columns
                For Each pro As PropertyInfo In temp.GetProperties()
                    propiedad = pro.Name
                    If pro.Name = colum.ColumnName Then
                        pro.SetValue(obj, dr(colum.ColumnName), Nothing)
                    Else
                        Continue For
                    End If
                Next
            Next
        Catch ex As Exception
            hayError_ = True
            mensajeError_ = ex.Message + " : " + propiedad
        End Try
        Return obj
    End Function

    Private Function ConvertirATipo(Of T)(ByVal dt As DataTable) As List(Of T)
        Dim data As List(Of T) = New List(Of T)()
        For Each row As DataRow In dt.Rows
            Dim item As T = GetItem(Of T)(row)
            data.Add(item)
        Next
        Return data
    End Function
    ''' <summary>
    ''' Función que contiene los resultados de ejecutar una consulta, obteniendo el tipo de 
    ''' clase especificado en T
    ''' <para>EJEMPLO:</para>
    ''' <para>Suponiendo que existe una clase Estudiante, entonces esta función se debe
    ''' mandar llamar de la siguiente manera:</para>
    ''' <para>List &lt;Estudiante> listaEstudiantes = New List&lt;Estudiante>();</para>
    ''' <para>listaEstudiantes = ObtenerResultados&lt;Estudiante>();</para>
    ''' <para>---</para>
    ''' <para>IMPORTANTE: Este método ÚNICAMENTE FUNCIONA CON CLASES EXACTAS AL
    ''' RESULTADO DEL PROCEDIMIENTO, FUNCIÓN O T-SQL</para>
    ''' </summary>
    ''' <typeparam name="T">El tipo de clase a utilizar y deseado a obtener</typeparam>
    ''' <returns>Listado de objetos T o null en caso de error</returns>
    Public Function ObtenerResultados(Of T)() As List(Of T)
        Dim dt As DataTable = New DataTable()
        Try
            Dim dr As SqlDataReader = oCmd.ExecuteReader()
            dt.Load(dr)
            hayError_ = False
        Catch ex As Exception
            hayError_ = True
            mensajeError_ = ex.Message
        End Try
        If Not HayError Then
            Return ConvertirATipo(Of T)(dt)
        Else
            Return Nothing
        End If
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: elimine el estado administrado (objetos administrados).
            End If

            ' TODO: libere los recursos no administrados (objetos no administrados) y reemplace Finalize() a continuación.
            ' TODO: configure los campos grandes en nulos.
            If (Not oCon Is Nothing) Then
                If oCon.State = ConnectionState.Open Then
                    oCon.Close()
                End If
                oCon.Dispose()
            End If
        End If
            disposedValue = True
    End Sub

    ' TODO: reemplace Finalize() solo si el anterior Dispose(disposing As Boolean) tiene código para liberar recursos no administrados.
    Protected Overrides Sub Finalize()
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' Visual Basic agrega este código para implementar correctamente el patrón descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(True)
        ' TODO: quite la marca de comentario de la siguiente línea si Finalize() se ha reemplazado antes.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
