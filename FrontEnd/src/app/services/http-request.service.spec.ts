import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpRequestService } from './http-request.service';

describe('HttpRequestService', () => {
  let service: HttpRequestService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HttpRequestService],
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(HttpRequestService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should return an object', () => {
    const name = 'testName';
    const mockResponse: any = { age: '12' };

    service.getResponse(name).subscribe((data: any) => {
      expect(data).toEqual(mockResponse);
    });

    const expectedUrl = `http://192.168.1.7:5000/Age/Index/${name}`;
    const req = httpMock.expectOne(expectedUrl);
    expect(req.request.method).toBe('GET');

    req.flush(mockResponse);
  });
});
