import { Constants, Urls } from './../core/constants/constants';
import { Observable } from 'rxjs/Observable';
import { ContactListResponse } from './../models/contact-list.model';
import { BaseHttpClientService } from './../core/services/base-http-client.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Injectable } from '@angular/core';
import { Contact } from '@app/models/contact.model';

@Injectable()
export class ContactService {
    constructor(private httpClientService: BaseHttpClientService) {

    }

    getAllContacts(): Observable<ContactListResponse> {
        return this.httpClientService.get(Urls.GetContacts);
    }

    getContact(contactId: number): Observable<Contact> {
        return this.httpClientService.get(Urls.GetContactsById + contactId.toString());
    }

    updateContact(contact: Contact): Observable<boolean> {
        return this.httpClientService.put(Urls.UpdateContact + contact.ID.toString(), contact);
    }

    addContact(contact: Contact): Observable<boolean> {
        return this.httpClientService.post(Urls.CreateContact, contact);
    }

    deleteContact(contactId: number): Observable<boolean> {
        return this.httpClientService.delete(Urls.DeleteContact + contactId);
    }
}
