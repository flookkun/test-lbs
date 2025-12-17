import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { PostServicesService } from './services/postServices.service';
import { LoadingService } from '../../loading/loading.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-my-page',
  standalone: true,
  imports: [CommonModule, FormsModule, AsyncPipe],
  templateUrl: './my-page.component.html',
  styleUrls: ['./my-page.component.scss'],
})
export class MyPageComponent {
  comments: any[] = [];
  newComment: string = '';

  constructor(private postService: PostServicesService, public loading: LoadingService) {}

  ngOnInit() {
    this.loadComments();
  }

  loadComments() {
    this.postService.getComment().subscribe((res) => {
      this.comments = res;
    });
  }

  submitComment() {
    if (!this.newComment.trim()) return;
    const payload = {
      comment: this.newComment,
      createBy: 2,
    };

    this.postService.postComment(payload).subscribe({
      next: (res) => {
        this.comments = [...this.comments, res];
        this.newComment = '';
      },
      error: (err) => {
        console.error('Insert failed', err);
        alert('ไม่สามารถบันทึกคอมเมนต์ได้');
      },
    });
  }
}
