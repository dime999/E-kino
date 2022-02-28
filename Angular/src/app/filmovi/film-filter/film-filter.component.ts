import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup } from '@angular/forms';
import { ProjekcijaService } from 'src/app/projekcija/projekcija.service';
import { ZanrService } from 'src/app/zanrovi/zanr.service';

@Component({
  selector: 'app-film-filter',
  templateUrl: './film-filter.component.html',
  styleUrls: ['./film-filter.component.css']
})
export class FilmFilterComponent implements OnInit {

  constructor(private formBuilder:FormBuilder,private projekcijaService:ProjekcijaService,private httpKlijent:HttpClient,private zanrService:ZanrService) { }
  form!:FormGroup;

  zanrovi:any;
  filmovi=[
    {title:'Spider-Man',poster:'https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg'},
    {title:'Južni vetar',poster:'https://upload.wikimedia.org/wikipedia/sr/thumb/1/1e/Ju%C5%BEni_vetar_%28film%29.jpeg/250px-Ju%C5%BEni_vetar_%28film%29.jpeg'},
    {title:'Inception',poster:'https://flxt.tmsimg.com/assets/p7825626_p_v10_af.jpg'},

  ];
  originalMovies=this.filmovi;

  projekcije:any;

  ngOnInit(): void {
    this.form=this.formBuilder.group({
      title:'',
      zanrID: 0,
      upcomingRealases:false,
      inTheaters: false,
      projekcija:'',
    });
    this.zanrService.getAll().subscribe((x:any)=>{
      this.zanrovi=x;
    })
    this.form.valueChanges.subscribe(values=>{
      this.filmovi=this.originalMovies;
      this.filterMovies(values);

    });

    this.projekcijaService.getAll().subscribe((x:any)=>{
      this.projekcije=x;
    });
  }
  filterMovies(values:any)
  {
    if(values.title)
    {
      this.filmovi=this.filmovi.filter(film=>film.title.indexOf(values.title)!==-1);
    }
  }

  cleanForm()
  {
    this.form.reset();

  }

}
