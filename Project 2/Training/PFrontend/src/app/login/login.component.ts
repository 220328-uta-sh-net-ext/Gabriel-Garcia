import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userName:string = "";
  password:string = "";

  error:boolean = false;

  // Create  onsubmit to handle submissions
  onSubmit():void{
    console.log(this.userName, this.password);
     this.loginService.login(this.userName, this.password)
     .subscribe((data) =>{
       console.log(data)
       // Let's store the data in our service's string
       this.loginService.token = data.token;
       console.log(this.loginService.token);
       // If we successfully login, let's redirect to the home page
       this.router.navigate(['home'])
     },
     (error) =>{
       console.log(error);
       // Makes error message appear through ngIf
       this.error = true;
     })
  }
  constructor(private loginService:LoginService, private router:Router) { }

  ngOnInit(): void {
  }

}
