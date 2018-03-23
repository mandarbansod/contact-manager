import { ContactService } from './../services/contact.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from '@app/models/contact.model';
import { ApplicationUrls } from '@app/core/constants/constants';

@Component({
  selector: 'app-view-contact',
  templateUrl: './view-contact.component.html',
  styleUrls: ['./view-contact.component.scss']
})
export class ViewContactComponent implements OnInit {
  routeSubscription: any;
  contactId: number;
  contact: Contact;

  constructor(private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router) {
    this.contact = new Contact();
  }

  ngOnInit() {
    this.routeSubscription = this.route.params.subscribe(params => {
      this.contactId = params['contactId'];

      this.contactService.getContact(this.contactId).subscribe(c => {
        this.contact = c;
      });
    });
  }

  onBackToContactListClick() {
    this.router.navigateByUrl(ApplicationUrls.ContactList);
  }

}
