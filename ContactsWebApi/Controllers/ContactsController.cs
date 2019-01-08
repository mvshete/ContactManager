using AutoMapper;
using ContactsWebApi.Application.Model;
using ContactsWebApi.Domain.Interface;
using ContactsWebApi.Domain.Model;
using ContactsWebApi.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactsWebApi.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactService _contactService;
        private const string InternalError = "An internal error has occurred.";
        private const string BadRequestError = "Part or all of the data is invalid.";

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]
        [Route(CustomRoutes.ContactRoute.List)]
        public IList<ContactDto> Get()
        {
            try
            {
                return _contactService.List().Select(Mapper.Map<ContactDto>).ToList();
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalError));
            }
        }

        [HttpPost]
        [Route(CustomRoutes.ContactRoute.Post)]
        public IHttpActionResult Post([FromBody] ContactDto contactToCreate)
        {
            try
            {
                if (contactToCreate == null)
                {
                    throw new InvalidDataException(BadRequestError);
                }

                var contact = new Contact
                {
                    FirstName = contactToCreate.FirstName,
                    LastName = contactToCreate.LastName,
                    Email = contactToCreate.Email,
                    Phone = contactToCreate.Phone,
                    Status = contactToCreate.Status
                };

                var response = _contactService.Post(contact);
                switch (response)
                {
                    case 0: return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created, "Request Entity Successfully Created."));
                    case 5000: return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, "There was a conflict creating an Entity."));
                    default: return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, InternalError));
                }
            }
            catch (InvalidDataException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalError));
            }
        }

        [HttpPut]
        [Route(CustomRoutes.ContactRoute.Put)]
        public IHttpActionResult Put([FromBody] ContactDto contactToUpdate, [FromUri] int id)
        {
            try
            {
                if (contactToUpdate == null)
                {
                    throw new InvalidDataException(BadRequestError);
                }

                if (id < 1)
                {
                    throw new InvalidDataException(BadRequestError);
                }

                var contact = new Contact
                {
                    Id = id,
                    FirstName = contactToUpdate.FirstName,
                    LastName = contactToUpdate.LastName,
                    Email = contactToUpdate.Email,
                    Phone = contactToUpdate.Phone,
                    Status = contactToUpdate.Status
                };

                var response = _contactService.Put(contact);
                switch (response)
                {
                    case 0: return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created, "Request Entity Successfully Updated."));
                    case 5000: return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, "There was a conflict updating an Entity."));
                    default: return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, InternalError));
                }
            }
            catch (InvalidDataException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalError));
            }
        }

        [HttpDelete]
        [Route(CustomRoutes.ContactRoute.Delete)]
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new InvalidDataException(BadRequestError);
                }

                var response = _contactService.Delete(id);
                switch (response)
                {
                    case 0: return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Request Entity Successfully deleted."));
                    case 5000: return ResponseMessage(Request.CreateResponse(HttpStatusCode.Conflict, "There was a conflict updating an Entity."));
                    default: return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, InternalError));
                }
            }
            catch (InvalidDataException ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, InternalError));
            }
        }

    }
}
