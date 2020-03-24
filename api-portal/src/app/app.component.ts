import { Component ,OnInit} from '@angular/core';
import {FormGroup,FormBuilder,ReactiveFormsModule, FormArray, FormControl} from '@angular/forms'
import {HttpClient,HttpResponse} from '@angular/common/http'
import { Subscription } from 'rxjs';
import {User} from './usermdel'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  subscription: Subscription;
  constructor(private http:HttpClient,private formBuilder:FormBuilder){ }
  data: Array<User>;
   name: Array<User>;
  userFormGroup:FormGroup
  result:string
  ngOnInit()
  {
      this.userFormGroup=this.formBuilder.group({
        firstName:[],
        lastName:[],
        password:[],
        country:['Country'],
        number:[],
        gender:[]
      })
      this.http.get("http://localhost:1773/api/User")
    .subscribe((res:Array<User>)=>{
      this.data=res
    });
  }
 
  Post()
  {
    this.subscription=this.http.post("http://localhost:1773/api/User/Post",{firstName:this.userFormGroup.controls.firstName.value,lastName:this.userFormGroup.controls.lastName.value,password:this.userFormGroup.controls.password.value,country:this.userFormGroup.controls.country.value,gender:this.userFormGroup.controls.gender.value}).subscribe(t=>{});
    window.location.reload();
    //console.log(this.userFormGroup.controls.gender.value)
  }

  Get()
  {
    this.http.get("http://localhost:1773/api/User/GetBy?id="+this.userFormGroup.controls.number.value)
    .subscribe((res:Array<User>)=>{
      this.name=res
      // console.log(this.data)
    });
  }
}