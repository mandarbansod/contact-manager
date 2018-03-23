import { ApplicationUrls } from './../core/constants/constants';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '@app/services/contact.service';
import { Contact } from '@app/models/contact.model';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.scss']
})
export class EditContactComponent implements OnInit {
  isLoading: boolean;
  msgs: { severity: string; summary: string; detail: string; }[];
  routeSubscription: any;
  contactId: number;
  contact: Contact;

  constructor(private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router) {
    this.contact = new Contact();
  }

  ngOnInit() {
    this.isLoading = true;
    this.routeSubscription = this.route.params.subscribe(params => {
      this.contactId = params['contactId'];
      if (this.contactId) {
        this.contactService.getContact(this.contactId).subscribe(c => {
          this.contact = c;
          this.isLoading = false;
        }, error => {
          console.log(error);
          this.isLoading = false;
        });
      } else {
        this.contact = new Contact();
      }
    });
  }

  onSubmit() {
    this.isLoading = true;
    this.msgs = [];
    if (this.contactId) {
      this.contactService.updateContact(this.contact).subscribe(c => {
        if (c) {
          this.msgs = [{ severity: 'success', summary: 'Saved Successfully.', detail: 'Record Updated Successfully.' }];
        } else {
          this.msgs = [{
            severity: 'error', summary: 'Error Occured',
            detail: 'Unable to process the request. Please try later'
          }];
          this.isLoading = false;
        }
      }, error => {
        this.msgs = [{ severity: 'error', summary: 'Error Occured', detail: error }];
        this.isLoading = true;
      });
    } else {
      this.contactService.addContact(this.contact).subscribe(c => {
        if (c) {
          this.msgs = [{ severity: 'success', summary: 'Saved Successfully.', detail: 'Record AddedSuccessfully.' }];
        } else {
          this.msgs = [{
            severity: 'error', summary: 'Error Occured',
            detail: 'Unable to process the request. Please try later'
          }];
          this.isLoading = false;
        }
      }, error => {
        this.msgs = [{ severity: 'error', summary: 'Error Occured', detail: error }];
        this.isLoading = false;
      });
    }
  }

  onCancelClick() {
    this.router.navigateByUrl(ApplicationUrls.ContactList);
  }

}
