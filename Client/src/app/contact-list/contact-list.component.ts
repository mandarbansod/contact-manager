import { Router } from '@angular/router';
import { ApplicationUrls } from './../core/constants/constants';
import { ContactService } from './../services/contact.service';
import { Component, OnInit } from '@angular/core';
import { Contact } from '@app/models/contact.model';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss'],
  providers: [ConfirmationService]
})
export class ContactListComponent implements OnInit {
  msgs: { severity: string; summary: string; detail: string; }[];
  contactList: any[];
  isLoading = false;

  constructor(private contactService: ContactService,
    private router: Router,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.isLoading = true;
    this.contactService.getAllContacts().subscribe(c => {
      this.contactList = c.ContactList;
    this.isLoading = false;
  });
  }

  getRouterLinkForViewContact(contact: Contact) {
    return ApplicationUrls.ViewContact + contact.ID;
  }

  getRouterLinkForEditContact(contact: Contact) {
    return ApplicationUrls.EditContact + contact.ID;
  }

  deleteSelectedContact(contact: Contact) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to delete?',
      header: 'Confirmation',
      icon: 'fa fa-question-circle',
      accept: () => {
        this.contactService.deleteContact(contact.ID).subscribe(c => {
          if (c) {
            this.msgs = [{ severity: 'success', summary: 'Confirmed', detail: 'The Record is deleted' }];
          } else {
            this.msgs = [{
              severity: 'error', summary: 'Confirmed',
              detail: 'An error occured while deleting the record.'
            }];
          }
        }, error => {
          this.msgs = [{
            severity: 'error', summary: 'Confirmed',
            detail: 'An error occured while deleting the record.'
          }];
        });
      }
    });
  }

  getRouterLinkForAddContact() {
    return ApplicationUrls.AddContact;
  }
}
