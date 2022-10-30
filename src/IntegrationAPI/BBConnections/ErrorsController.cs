﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IntegrationLibrary.Core.Model;
using System;
using System.IO;
using System.Net;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace IntegrationAPI.BBConnections
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("Error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = HttpStatusCode.InternalServerError;

            if (exception is KeyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            else if (exception is User.DuplicateEMailException) code = HttpStatusCode.MultipleChoices;
            else if (exception is FileNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is NotImplementedException) code = HttpStatusCode.NotImplemented;
            else if (exception is BadHttpRequestException) code = HttpStatusCode.BadRequest;
            else if (exception is Exception) code = HttpStatusCode.BadRequest;

            Response.StatusCode = ((int)code);

            return new ErrorResponse(exception);
        }
    }
}
